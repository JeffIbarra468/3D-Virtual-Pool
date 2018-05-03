using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//play info own lobbyNetworkHook
public class LobbyNetworkHook : NetworkBehaviour
{
    public GameObject chatPointer;
    public GameObject Pname;//
    public InputField userInputField;//
    public string username;//
    
    //private int locker = 0; 


    // Use this for initialization
    void Start()
    {
        //System.Threading.Thread.Sleep(3000);
        if (hasAuthority)
            Debug.Log("I have authourity");

        chatPointer = GameObject.Find("chatMemory");  //chatMemory object own chat.cs

        if (!hasAuthority)
        {
            return;
        }
        else
        {            
            chatPointer.GetComponent<LobbyChat>().playerPointer = this.gameObject;
            //the above means chatMemory.GetComponent<LobbyChat>().playerPointer = this.gameObject;
        }
        Debug.Log(isLocalPlayer);
    }

    void Update()
    {       
        Pname = this.transform.Find("PlayerName").gameObject;
        userInputField = Pname.GetComponent<InputField>();
        username = userInputField.text;
    }


    void OnConnectedToServer()
    {
    }

    [Command]
    public void CmdChatMess_clientToServer(string mess)
    {
        Debug.Log("server received");
        RpcChatMess_serverToAllClient(mess);
    }


    [ClientRpc]
    public void RpcChatMess_serverToAllClient(string mess)
    {
        Debug.Log("client received");

        chatPointer.GetComponent<LobbyChat>().chatList.Add(username + ": " + mess); //username1 + ": " +
    }

}
