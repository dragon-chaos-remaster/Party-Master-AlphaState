using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPropPlayer : MonoBehaviour
{
    //[SerializeField] List<Collider> playersToGet = new List<Collider>();

    [SerializeField] Transform playerHands;
    //[SerializeField] Camera gameMasterCam;
    [SerializeField] float getRange;
    [SerializeField] LayerMask propPlayerLayer;
    RaycastHit hit;
    bool pickUp;

    [SerializeField] Pooling effectPooling;
    // Start is called before the first frame update
    void DetectPropPlayer()
    {
       
        pickUp = Physics.Raycast(playerHands.position, playerHands.forward, out hit, getRange, propPlayerLayer);
        if (pickUp)
        {  
            print("Hitted:" + hit.transform.name);
            bool isAPlayer = hit.transform.CompareTag("PropPlayer");
            if (isAPlayer)
            {
                print("Player Detected");
                hit.transform.gameObject.SetActive(false);
                GameObject aux = effectPooling.GetPooledObject();
                if (aux != null)
                {
                    aux.transform.position = hit.transform.position;
                    aux.transform.rotation = hit.transform.rotation;
                    aux.SetActive(true);
                }
            }
            else
            {
                print("Not a Player");
               // return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DetectPropPlayer();
            Debug.DrawRay(playerHands.position, playerHands.transform.forward * hit.distance, Color.red);
            
        }
    }
}
