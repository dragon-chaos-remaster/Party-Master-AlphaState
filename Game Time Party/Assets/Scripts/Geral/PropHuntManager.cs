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
    [SerializeField] TimeLimitManager timeLimit;
    [SerializeField] ParentChildrenListing spawnPointParent;
    [SerializeField] List<Transform> propPositions;
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
            //propPlayers.Add(GameObject.FindGameObjectWithTag("PropPlayer").GetComponent<PlayerScores>());
        }       
        RandomizeProps();
    }
    /// <summary>
    /// Organiza os props em uma posição aleatória, de acordo com o número de pontos de spawn no mapa
    /// </summary>
    void RandomizeProps()
    {
        for (int i = 0; i < propPositions.Count; i++)
        {
            propPositions[i].position = spawnPointParent.ChildCount[i].transform.position;
            propPositions[i].rotation = spawnPointParent.ChildCount[i].transform.rotation;
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
    private void Update()
    {
        if(numeroDePlayersPegos == totalDePlayers - 1)
        {
            timeLimit.gameStates = GameStates.Finished;
        }
    }

}
