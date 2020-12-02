using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Image[] imagesToAnimate;
    
    
    public void NextScene()
    {
        StartCoroutine(SmoothTransition(3));
    }
    IEnumerator SmoothTransition(int buildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
        
        while(!operation.isDone)
        {
            float progresso = Mathf.Clamp01(operation.progress / .9f);
            foreach(Image image in imagesToAnimate)
            {
                image.fillAmount = progresso;
            }
            yield return null;
        }
    }
}
