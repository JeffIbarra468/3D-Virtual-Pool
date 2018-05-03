using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ballBehavior : NetworkBehaviour {

    public int ballType; //0,1,2,3 for BLANK, SOLID, STRIPE, 8-ball
    public float goalY; //terrain designer will decide the Z of goal
    public int currentTeam;
    public GameObject scoreBoard;
    public GameObject scorePointer;
    private bool isOnTable;
    private bool Locker = false;


    private Vector3 originPos;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().mass = 0.4f;
        GetComponent<Rigidbody>().drag = 0.3f;
        GetComponent<Rigidbody>().angularDrag = 0.05f;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        isOnTable = true;
        scoreBoard = GameObject.Find("scoreControl");
        goalY = transform.position.y;

        originPos = this.transform.position;
        GetComponent<Rigidbody>().isKinematic = false;
    }
	
	// Update is called once per frame
	void Update () {

       

        if (isServer)
            {
                UpdateCurrentTeam();
                CheckBallIn();
            }
	}

    


    void UpdateCurrentTeam()
    {
        if (!Locker)
        {
            GameObject go = GameObject.Find("scoreMemory(Clone)");

            if (!go)
            {
                //Debug.Log("I can't find scoreMemory");
                return;
            }
            else
            {
                //Debug.Log(go.name);
                scorePointer = go;

                Locker = true;
            }
        }

        
    }


    void CheckBallIn()
    {
        if ((goalY - transform.position.y > 2.0f) && (isOnTable))
        {
            Debug.Log("Ball is in hole");
            isOnTable = false;

            if (ballType == 0)
            {
                //Set location of BLANK ball to the center
                this.transform.position = originPos;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().isKinematic = true;

                isOnTable = true;

                GetComponent<Rigidbody>().isKinematic = false;
                SwitchTeam();
            } else if (ballType == 3)
            {
                
                if (scorePointer.GetComponent<ScoreControl>().getScoreTeam(currentTeam) == 7)
                {
                    //currentTeam win
                    Debug.Log("Current Team win");
                } else
                {
                    //currentTeam lose

                    Debug.Log("Current Team lose");
                }
                

            } else
            {
                if (ballType % 2 == currentTeam)
                {
                    //currentTeam gain 1 point and keep going
                    scorePointer.GetComponent<ScoreControl>().addScoreTeam(currentTeam);

                } else
                {
                    scorePointer.GetComponent<ScoreControl>().addScoreTeam(1-currentTeam);
                    SwitchTeam();
                }

            }

        }
    }

    
    public void SwitchTeam()
    {
        if (!Locker)
            return;

        scorePointer.GetComponent<ScoreControl>().switchTeam();
       
    }

}
