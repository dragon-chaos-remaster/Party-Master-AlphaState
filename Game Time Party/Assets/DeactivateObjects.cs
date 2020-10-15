using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjects : MonoBehaviour
{
    [SerializeField] float countdown;
    float aux;
    void Start()
    {
        aux = countdown;
    }

    
    void LateUpdate()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            gameObject.SetActive(false);
            countdown = aux;
        }
    }
}
