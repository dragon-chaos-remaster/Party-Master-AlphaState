using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class CurrentRoomCanvas : MonoBehaviour
{
    RoomCanvases roomCanvases;
    
    public void Initialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    public void Show()
    {    
        gameObject.SetActive(true);
    }
    void Hide()
    {
        gameObject.SetActive(false);
        
    }
    
}
