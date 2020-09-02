using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SpecialEffectsCanvas : MonoBehaviour
{
    RoomCanvases roomCanvases;
    [SerializeField] RawImage blackScreen;
    public void Initalize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn(1f));
    }
    IEnumerator FadeIn(float duration)
    {
        blackScreen.DOFade(1f,duration);
        yield return new WaitForSeconds(duration);
        blackScreen.DOFade(0f,duration);
        roomCanvases.CurrentRoomCanvas.Show();
    }
}
