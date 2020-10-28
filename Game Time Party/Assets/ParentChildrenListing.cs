using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChildrenListing : MonoBehaviour
{
    [SerializeField] Transform theParent;
    [SerializeField] List<GameObject> childCount = new List<GameObject>();
    
    
    void Awake()
    {
        foreach(Transform child in theParent)
        {
            childCount.Add(child.gameObject);
        }
    }

    /// <summary>
    /// Pega todos os objetos da lista 
    /// </summary>
    /// <returns></returns>
    public GameObject GetChildren()
    {
        foreach(GameObject child in childCount)
        {
            if (childCount.Count != 0)
            {
                //print("HHHHHHHHHHHHHHHHHHHHHHHH");
                return child;
            }
            else
            {
                Debug.LogError("There are no children objects in this parent!");
            }
        }
        return null;
    }

    public void ActivateParent()
    {
        theParent.gameObject.SetActive(true);
    }
    /// <summary>
    /// Desativa o Parente do objeto 
    /// </summary>
    public void DeactivateParent()
    {
        theParent.gameObject.SetActive(false);
    }
    public void ActivateAllChildren()
    {
        GetChildren().SetActive(true);
    }
    public void ActivateChildren(int numberOfChildren)
    {
        for (int i = 0; i < numberOfChildren; i++)
        {
            childCount[i].SetActive(true);
        }
    }
    public void DeactivateAllChildren()
    {
        GetChildren().SetActive(false);
    }
    public void DeactivateChildren(int numberOfChildren)
    {
        for (int i = 0; i < numberOfChildren; i++)
        {
            childCount[i].SetActive(false);
        }
    }
    
}
