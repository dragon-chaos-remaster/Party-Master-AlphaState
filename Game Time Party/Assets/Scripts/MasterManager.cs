using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField] GameManager gameManager;

    public static GameManager GameManager { get { return Instance.gameManager; } }
    
}
