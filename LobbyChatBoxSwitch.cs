using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyChatBoxSwitch : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    void ChatOnOff()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {

            this.GetComponent<LobbyChat>().enabled = !this.GetComponent<LobbyChat>().enabled;

        }
    }

    // Update is called once per frame
    void Update()
    {
        ChatOnOff();
    }
}
