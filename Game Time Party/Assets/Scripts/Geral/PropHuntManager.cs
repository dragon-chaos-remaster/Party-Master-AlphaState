using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using TMPro;
public class PropHuntManager : MonoBehaviour
{
    public static int numeroDePlayersPegos;
    [SerializeField] int totalDePlayers = 4;
    [SerializeField] GameObject gameMaster;
    [SerializeField] List<PlayerScores> propPlayers;
    //[SerializeField] UnityEvent distributeEvents;

    [SerializeField] List<TextMeshProUGUI> scoreTexts;
    static PropHuntManager instance;
    public static PropHuntManager Instance { get { return instance; } }
    void Awake()
    {
        instance = this;
        totalDePlayers = propPlayers.Count;
        for (int i = 0; i < scoreTexts.Count; i++)
        {
            scoreTexts[i].gameObject.SetActive(false);
        }
    }
    public void DistributePoints()
    {
        for (int i = 0; i < totalDePlayers; i++)
        {          
            if (propPlayers[i].CompareTag("GameMaster"))
            {
                scoreTexts[i].text = "GameMaster: " + propPlayers[i].ThisPlayerScore.ToString();
            }
            else
            {
                scoreTexts[i].text = "Player " + i + ": " + propPlayers[i].ThisPlayerScore.ToString();
            }
            scoreTexts[i].gameObject.SetActive(true);
        }
    }

    
}
