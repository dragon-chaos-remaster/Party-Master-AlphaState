using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum GameStates { Contando, Finished }
public class TimeLimitManager : MonoBehaviour
{
    [SerializeField] float countdown = 60f;
    float auxValue;
    GameStates gameStates;
    [SerializeField] Image counter_Text;
    [SerializeField] PumpLetters lettersToPump;
    bool timeLimitExpired;
    void Start()
    {
        DOTween.Init(false, false, LogBehaviour.Verbose).SetCapacity(400,100);
        auxValue = countdown;
    }

    void CountingTime()
    { 
        
        if (gameStates == GameStates.Contando)
        {
            countdown -= Time.deltaTime;          
            counter_Text.DOFillAmount(0, auxValue);
            
        }
        if(countdown <= 0 && !timeLimitExpired)
        {
            //Coisas acontecem
            timeLimitExpired = true;
            StartCoroutine(EndGame());
            gameStates = GameStates.Finished;
            
        }
    }
    IEnumerator EndGame()
    {
        //Time.timeScale = 0;
        Debug.LogWarning("TIME'S UP");
        StartCoroutine(lettersToPump.PunchScaleLetters(0.9f,0.3f));
        yield return new WaitForSecondsRealtime(5f);
        //Time.timeScale = 1;
        gameStates = GameStates.Contando;
        countdown = auxValue;
    }
    void Update()
    {
        CountingTime();
    }
}
