using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public List<GameObject> listaDeObjetos = new List<GameObject>();
    [SerializeField] GameObject prefab;
    [SerializeField] int numberOfObjects;
    [SerializeField] bool willGroup;

    void Awake()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject pooledObj = Instantiate(prefab);
            pooledObj.SetActive(false);
            listaDeObjetos.Add(pooledObj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < listaDeObjetos.Count; i++)
        {
            if (!listaDeObjetos[i].activeInHierarchy)
            {
                return listaDeObjetos[i];
            }
        }
        if (willGroup)
        {
            GameObject pooledObj = Instantiate(prefab);
            listaDeObjetos.Add(pooledObj);
            return pooledObj;
        }
        return null;
    }
}
