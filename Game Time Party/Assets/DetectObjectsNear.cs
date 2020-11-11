using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectObjectsNear : MonoBehaviour
{
    //[SerializeField] Vector3[] detectedObjects;
    [SerializeField] Transform whoDetects;
    [SerializeField] float detectionValue;
    [SerializeField] Transform[] objectsToDetect;

    [SerializeField] Image meterSprite;
    [SerializeField] Gradient colorsToChange;
    [SerializeField] ParticleSystem closerHighlight;
    [SerializeField] bool hasPlayed;
    //[SerializeField] bool autoUpdate;

    /// <summary>
    /// Muda a cor da Imagem de acordo com as cores do gradiente. 
    /// Também checa os valores do paramêtro para executar funções.  
    /// </summary>
    /// <param name="evaluationValue"></param>
    void ChangeMeterColor(float evaluationValue)
    {       
        //Calculo para fazer com que os valores só interpolem entre 0 e 1, sendo 0f o valor minimo e 300f o valor máximo
        evaluationValue = Mathf.InverseLerp(0f, 300f, evaluationValue);
        meterSprite.color = colorsToChange.Evaluate(evaluationValue);
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print(evaluationValue);
        }
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
                detectionValue = Vector3.Distance(transform.position, objectsToDetect[i].position);
                ChangeMeterColor(detectionValue);
            }
        }
        else
        {
            for (int i = 0; i < objectsToDetect.Length; i++)
            {
                detectionValue = Vector3.Distance(whoDetects.position, objectsToDetect[i].position);
                ChangeMeterColor(detectionValue);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < objectsToDetect.Length; i++)
        {
            //detectionValue = Vector3.Distance(whoDetects.position, objectsToDetect[i].position);
            Gizmos.DrawLine(whoDetects.position,objectsToDetect[i].position);
        }
        
        
    }
    private void LateUpdate()
    {
        SearchingForObjects();
        
    }
}
