using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreManager : MonoBehaviour
{
    public static int pontuacaoGeral;
    public int[] playerScores = new int[5];
    [SerializeField] List<GameObject> players = new List<GameObject>();
    static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    void Awake()
    {
        instance = this;       
    }

    public IEnumerator CheckScore()
    {
        foreach(GameObject player in players)
        {
            if (player.CompareTag("GameMaster"))
            {
                print("GameMaster is: " + player.name);
            }
            yield return new WaitForSeconds(0.75f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
