using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    
    public int ScoreSolid = 0;

    
    public int ScoreStripe = 0;

    private int Locker = 0;

    public int previousScore = 0;
	public Text sscoreSolid;
	public Text sscoreStripe;

    public GameObject scorePointer;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
        
        UpdateScore();
        CheckInScore();
    }


    void UpdateScore()
    {
        if (Locker == 0)
        {
            GameObject go = GameObject.Find("scoreMemory(Clone)");

            if (!go)
            {
                Debug.Log("I can't find scoreMemory");
                return;
            }
            else
            {
                Debug.Log(go.name);
                scorePointer = go;

                Locker = 1;
            }
        }

        ScoreSolid = scorePointer.GetComponent<ScoreControl>().getScoreTeam(0);
        ScoreStripe = scorePointer.GetComponent<ScoreControl>().getScoreTeam(1);
    }

    void CheckInScore()
    {
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ScoreSolid = previousScore + 1;
            previousScore = ScoreSolid;
            Debug.Log(ScoreSolid);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ScoreStripe = previousScore - 1;
            previousScore = ScoreStripe;
            Debug.Log(ScoreStripe);
        }
        */

        sscoreSolid.text = ScoreSolid.ToString();
        sscoreStripe.text = ScoreStripe.ToString();
    }
}
