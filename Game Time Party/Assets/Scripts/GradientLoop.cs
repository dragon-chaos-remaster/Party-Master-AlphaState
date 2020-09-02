using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GradientLoop : MonoBehaviour
{
    [SerializeField] RawImage backgroundImage;
    [SerializeField] Gradient gradient;
    bool colorsHaveEnded;
    float sineTime = 0f;


    void SineValue()
    {
        if (!colorsHaveEnded)
        {
            sineTime += Time.deltaTime * .45f;
        }
        else
        {
            sineTime -= Time.deltaTime * .45f;
        }
        if (sineTime < 0)
        {
            colorsHaveEnded = false;
        }
        if (sineTime > .95f)
        {
            colorsHaveEnded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SineValue();
        backgroundImage.color = gradient.Evaluate(Mathf.Clamp(sineTime,0f,1f));
        //print(sineTime);
    }
}
