using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectObjectsNear : MonoBehaviour
{
    //[SerializeField] Vector3[] detectedObjects;
    [SerializeField] Transform whoDetects;
    [SerializeField] float[] detectionValue;
    [SerializeField] Transform[] objectsToDetect;

    [SerializeField] List<Image> meterSprite = new List<Image>();
    int index = -1;
    [SerializeField] Gradient colorsToChange;
    [SerializeField] ParticleSystem closerHighlight;
    [SerializeField] bool hasPlayed;
    //[SerializeField] bool autoUpdate;

    /// <summary>
    /// Muda a cor das Imagens de acordo com as cores do gradiente. 
    /// Também checa os valores do paramêtro para executar funções.  
    /// </summary>
    /// <param name="evaluationValue"></param>
    void ChangeMeterColor(float evaluationValue, Image meterSprite)
    {
        //Calculo para fazer com que os valores só interpolem entre 0 e 1, sendo 0f o valor minimo e 300f o valor máximo
        evaluationValue = Mathf.InverseLerp(0f, 300f, evaluationValue);
        meterSprite.color = colorsToChange.Evaluate(evaluationValue);
        
        
        var rateOveertime = closerHighlight.emission.rateOverTime;
        float countdown = 2f;
        if (evaluationValue <= 0.5f && (!hasPlayed))
        {
            closerHighlight.Play();
            hasPlayed = true;
        }
        if (evaluationValue <= 0.2f && (!hasPlayed))
        {
            rateOveertime.constant = 2f;
            hasPlayed = true;
        }
        if(hasPlayed)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                hasPlayed = false;
                countdown = 2f;
            }
        }
    }
    void SearchingForObjects()
    {
        if (whoDetects != null)
        {
            for (int i = 0; i < objectsToDetect.Length; i++)
            {
                detectionValue[i] = Vector3.Distance(transform.position, objectsToDetect[i].position);
                ChangeMeterColor(detectionValue[i], meterSprite[i]);
            }
        }
        else
        {
            for (int i = 0; i < objectsToDetect.Length; i++)
            {
                detectionValue[i] = Vector3.Distance(whoDetects.position, objectsToDetect[i].position);
                ChangeMeterColor(detectionValue[i], meterSprite[i]);
                
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if(objectsToDetect.Length == 0)
        {
            return;
        }
        for (int i = 0; i < objectsToDetect.Length; i++)
        {
            //detectionValue = Vector3.Distance(whoDetects.position, objectsToDetect[i].position);
            Gizmos.DrawLine(whoDetects.position,objectsToDetect[i].position);
        }
        
        
    }
    private void LateUpdate()
    {
        SearchingForObjects();
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print(index);
            index++;
            meterSprite[index].gameObject.SetActive(true);
            meterSprite[index + 1].gameObject.SetActive(false);
            if(meterSprite[index + 1] == null)
            {
                meterSprite[index - 1].gameObject.SetActive(true);
            }
            
        }
        if (index >= meterSprite.Count - 1)
        {
            index = -1;
            print("Entereia aqui");
        }
    }
}
