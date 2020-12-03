﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public enum GameStates { Contando, Finished }
public class TimeLimitManager : MonoBehaviour
{
    [SerializeField] float countdown = 60f;
    float auxValue;
    public GameStates gameStates;
    [SerializeField] Image counter_Text;
    [SerializeField] PumpLetters lettersToPump;
    //WaitForSecondsRealtime waitTime;
    bool timeLimitExpired, gameEnded;
    void Start()
    {
        DOTween.Init(false, false, LogBehaviour.Verbose).SetCapacity(400,100);
        auxValue = countdown;
    }

    public WaitForSecondsRealtime WaitingDuration(float duration)
    {
        return new WaitForSecondsRealtime(duration);
    }
    void CountingTime()
    { 
        
        if (gameStates == GameStates.Contando)
        {
            countdown -= Time.deltaTime;          
            counter_Text.DOFillAmount(0, auxValue);
            
        }
        if(gameStates == GameStates.Finished && !gameEnded)
        {
            gameEnded = true;
            StartCoroutine(EndGame());
        }
        if(countdown <= 0 && !timeLimitExpired)
        {
            //Coisas acontecem
            timeLimitExpired = true;           
            gameStates = GameStates.Finished;
            
        }
    }
    IEnumerator EndGame()
    {
        Time.timeScale = 0;
        //Debug.LogWarning("TIME'S UP");
        StartCoroutine(lettersToPump.PunchScaleLetters(0.9f,0.3f));
        yield return WaitingDuration(2f);
        PropHuntManager.Instance.DistributePoints();
        yield return WaitingDuration(5f);
        Time.timeScale = 1;
        //gameStates = GameStates.Contando;
        //countdown = auxValue;
        SceneManager.LoadScene(2);
    }
    void Update()
    {
        CountingTime();
    }
}
