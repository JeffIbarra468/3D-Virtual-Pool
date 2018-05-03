using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActivateLBChat : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnConnectedToServer()
    {
        GetComponent<LobbyChat>().enabled = true;
    }

    private void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        GetComponent<LobbyChat>().enabled = false;
    }
}
