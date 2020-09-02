using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/GameManager")]
public class GameManager : ScriptableObject
{
    [SerializeField] string gameVersion = "0.0.0";

    public string GameVersion { get { return gameVersion; } }

    [SerializeField] string nickname = "Elhiana";
    public string NickName 
    { 
        get 
        {
            int randomValue = Random.Range(0, 9999);
            return nickname + randomValue.ToString();
        } 
    }
}
