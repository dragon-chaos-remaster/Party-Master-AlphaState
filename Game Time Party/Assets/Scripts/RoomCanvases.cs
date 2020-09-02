using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField] CreateOrJoinRoomCanvas createOrJoinRoomCanvas;
    [SerializeField] CurrentRoomCanvas currentRoomCanvas;
    [SerializeField] SpecialEffectsCanvas specialEffectsCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get { return createOrJoinRoomCanvas; } }

    public CurrentRoomCanvas CurrentRoomCanvas { get { return currentRoomCanvas; } }
    public SpecialEffectsCanvas SpecialEffectsCanvas{ get {return specialEffectsCanvas; } }
    private void Awake()
    {
        FirstInitialized();
    }
    void FirstInitialized()
    {
        CreateOrJoinRoomCanvas.Initialize(this);
        CurrentRoomCanvas.Initialize(this);
        SpecialEffectsCanvas.Initalize(this);
    }
}
