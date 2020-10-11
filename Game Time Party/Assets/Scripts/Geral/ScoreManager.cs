using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreManager : MonoBehaviour
{
    public int pontuacaoGeral;

    [SerializeField] Dictionary<string, List<PlayerScores>> playersDictionary = new Dictionary<string, List<PlayerScores>>();

    [SerializeField] List<PlayerScores> playerScores = new List<PlayerScores>();
    static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    void Awake()
    {
        instance = this;       
        
    }

    public IEnumerator CheckScore()
    {
        yield return new WaitForSeconds(1f);
    }
    
}
