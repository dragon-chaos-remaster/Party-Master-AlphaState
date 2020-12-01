using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    bool curtainAppeared;
    [SerializeField] Button novaPartidaBotaoClone;
    public void CurtainEffect(Image curtainObject)
    {
        curtainAppeared = true;
        DOTween.Init(true, true);
        curtainObject.DOFillAmount(10f, 1f);
        novaPartidaBotaoClone.gameObject.SetActive(true);
    }
    public void CurtainEffectBackwards(Image curtainObject)
    {
        curtainAppeared = false;
        curtainObject.DOFillAmount(0f,1f);
        novaPartidaBotaoClone.gameObject.SetActive(false);
        
       
    }
    

}
