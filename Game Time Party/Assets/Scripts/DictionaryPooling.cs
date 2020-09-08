using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        string objectTag;
        GameObject prefab;
        int size;
        public string ObjectTag { get { return objectTag; } set { objectTag = value; } }
        public GameObject Prefab { get { return prefab; } set { prefab = value; } }
        public int Size { get { return size; } set { size = value; } }
    }

    [SerializeField] Dictionary<string, Queue<GameObject>> poolingDictionary = new Dictionary<string, Queue<GameObject>>();
    [SerializeField] List<Pool> pools = new List<Pool>();
    Queue<GameObject> filaDeObjetos = new Queue<GameObject>();
    void Start()
    {
        foreach(Pool pool in pools)
        {
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                filaDeObjetos.Enqueue(obj);
            }
            poolingDictionary.Add(pool.ObjectTag, filaDeObjetos);
        }
    }

    
    public GameObject SpawnFromPool(string tag,Vector3 spawnPosition,Quaternion spawnRotation)
    {
        if (!poolingDictionary.ContainsKey(tag))
        {
            print("Pool with tag: " + tag + " missing");
            return null;
        }
        GameObject objSpawn = poolingDictionary[tag].Dequeue();

        objSpawn.SetActive(true);
        objSpawn.transform.position = spawnPosition;
        objSpawn.transform.rotation = spawnRotation;

        poolingDictionary[tag].Enqueue(objSpawn);

        return objSpawn;
    }
}
