using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI roomName;

    RoomCanvases roomCanvases;

    public void FirstInitialized(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            print("You are not connected!");
            return;
        }
        //CreateRoom
        //CreateOrJoinRoom
        RoomOptions roomOptions = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 5
        };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully", this);
        roomCanvases.SpecialEffectsCanvas.StartFadeIn();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Creation of the room failed " + message, this);
        
    }

}
