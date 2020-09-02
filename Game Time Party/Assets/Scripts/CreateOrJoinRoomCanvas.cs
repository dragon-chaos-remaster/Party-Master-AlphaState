using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField] CreateRoomMenu createRoomMenu;
    RoomCanvases roomCanvases;
    public void Initialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
        createRoomMenu.FirstInitialized(canvases);
    }
}
