using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conectando ao servidor.",this);
        PhotonNetwork.NickName = MasterManager.GameManager.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameManager.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to server: " + PhotonNetwork.CloudRegion + " Player's Nickname: " + PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected for reason: " + cause.ToString());
        
    }

}
