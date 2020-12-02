using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    bool curtainAppeared, creditos;
    [SerializeField] Button novaPartidaBotaoClone;
    [SerializeField] RectTransform nomeCreditos;
    [SerializeField] GameObject creditosCanvas, controlesCanvas;
    [SerializeField] Image creditosMaskara;
    [SerializeField] ParentChildrenListing profissions;

    #region NOVA PARTIDA BOTÃO
    public void CurtainEffect(RectTransform curtainObject)
    {
        curtainAppeared = true;
        DOTween.Init(true, true);
        curtainObject.DOAnchorPosY(1f, 1f);
        novaPartidaBotaoClone.gameObject.SetActive(true);
    }
    public void CurtainEffectBackwards(RectTransform curtainObject)
    {
        curtainAppeared = false;
        curtainObject.DOAnchorPosY(177f,1f);
        novaPartidaBotaoClone.gameObject.SetActive(false);
        
       
    }
    #endregion

    public void MostrarControles(Image mask)
    {
        controlesCanvas.SetActive(true);
        mask.GetComponent<Renderer>().sharedMaterial.DOFade(255f, 1f);
    }

    #region CRÉDITOS BOTÃO
    public void MoveToTheSide(RectTransform nomes)
    {
        nomes.DOAnchorPosX(142f, .55f);
    }
    public void Creditos(ParentChildrenListing profissons)
    {
        StartCoroutine(CreditosAnimados(profissons, -327f, .55f,false));
    }
    IEnumerator CreditosAnimados(ParentChildrenListing textPro, float tweeningValue,float duration, bool allAtOnce)
    {
        for (int i = 0; i < textPro.GetChildren().Length; i++)
        {
            if (!allAtOnce)
            {
                textPro.GetChildren()[i].GetComponent<RectTransform>().DOAnchorPosX(tweeningValue, duration);
                yield return new WaitForSeconds(duration * .75f);
            }
            else
            {
                textPro.GetChildren()[i].GetComponent<RectTransform>().DOAnchorPosX(tweeningValue, duration);
                yield return null;
            }
        }
    }
    #endregion
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            creditosCanvas.SetActive(false);
            creditosMaskara.GetComponent<Renderer>().sharedMaterial.DOFade(0f, 1f);
        }
        //if (!creditosCanvas.activeInHierarchy)
        //{
        //    nomeCreditos.anchoredPosition = new Vector2(610, 0f);
        //    foreach(GameObject eachText in profissions.ChildCount)
        //    {
                
        //    }
        //}
    }


}
