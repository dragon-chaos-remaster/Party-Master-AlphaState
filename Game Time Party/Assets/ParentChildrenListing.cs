using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ParentChildrenListing : MonoBehaviour
{
    [SerializeField] Transform theParent;
    [SerializeField] List<GameObject> childCount;

    public List<GameObject> ChildCount => childCount;
    
    void Awake()
    {
        childCount = new List<GameObject>();
        foreach (Transform child in theParent)
        {
            childCount.Add(child.gameObject);
        }
    }

    /// <summary>
    /// Pega todos os objetos da lista 
    /// </summary>
    /// <returns></returns>
    public GameObject[] GetChildren()
    {
        foreach(GameObject child in childCount)
        {
            if (childCount.Count != 0)
            {
                print(child);
                //return child;
            }
        }
        return childCount.ToArray();
    }
    public int GetNumberOfChildren()
    {
        return childCount.Count;
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
        for (int i = 0; i < childCount.Count; i++)
        {
            childCount[i].SetActive(true);
        }
       
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
        for (int i = 0; i < childCount.Count; i++)
        {
            childCount[i].SetActive(false);
        }
    }
    public void DeactivateChildren(int numberOfChildren)
    {
        for (int i = 0; i < numberOfChildren; i++)
        {
            childCount[i].SetActive(false);
        }
    }
    
}
