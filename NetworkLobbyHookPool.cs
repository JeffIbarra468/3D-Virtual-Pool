using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;


public class NetworkLobbyHookPool : LobbyHook
{
    //public string playername;
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PlayerNetworkHook localPlayer = gamePlayer.GetComponent<PlayerNetworkHook>();
        localPlayer.pname = lobby.playerName;        
    }
}
