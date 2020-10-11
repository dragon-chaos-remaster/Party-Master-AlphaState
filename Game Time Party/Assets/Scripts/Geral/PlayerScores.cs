using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScores : MonoBehaviour
{
    int score;

    public int ThisPlayerScore
    {
        get { return score; }

        set { score = value; }
    }
    public int GetScore
    {
        get { return score; }
    }
    public int SetScore
    {
        set { score = value; }
    }
    
}
