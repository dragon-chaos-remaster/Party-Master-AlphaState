using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PumpLetters : MonoBehaviour
{
    [SerializeField] List<Transform> letters = new List<Transform>();

    [SerializeField] Image[] backgroundSprites;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform letter in transform)
        {
            letters.Add(letter);
            letter.gameObject.SetActive(false);
        }
    }

    public IEnumerator PunchScaleLetters(float amount,float duration)
    {
        for(int i = 0; i < letters.Count; i++)
        {
            letters[i].gameObject.SetActive(true);
            letters[i].DORewind();
            letters[i].DOPunchScale(letters[i].localScale * amount, duration,1).SetUpdate(true);
            yield return new WaitForSecondsRealtime(.15f);
        }
        foreach(Image oilPaint in backgroundSprites)
        {
            oilPaint.DOFillAmount(1, 0.9f).SetUpdate(true);
        }
    }
}
