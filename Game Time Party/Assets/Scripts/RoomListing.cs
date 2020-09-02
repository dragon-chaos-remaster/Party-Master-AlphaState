using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
public class RoomListing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoom(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
}
