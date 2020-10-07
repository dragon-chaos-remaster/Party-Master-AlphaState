using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] List<CharacterMovement> playersToSwitch = new List<CharacterMovement>();
    //[SerializeField] List<CharacterMovingRigidBody> playersRigidToSwitch = new List<CharacterMovingRigidBody>();
    [SerializeField] List<GameObject> playerCameras = new List<GameObject>();
    int playerPointer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerPointer++;
            Switch();
        }
        if(playerPointer >= playersToSwitch.Count - 1)
        {
            playerPointer = -1;
        }
    }
    void Switch()
    {
       
         switch (playerPointer)
         {
             case 0:

                playersToSwitch[playerPointer].enabled = true;
                playerCameras[playerPointer].SetActive(true);
                playersToSwitch[playerPointer + 1].enabled = false;
                playerCameras[playerPointer + 1].SetActive(false);
                playersToSwitch[playerPointer + 2].enabled = false;
                playerCameras[playerPointer + 2].SetActive(false);
                break;
             case 1:
                playersToSwitch[playerPointer - 1].enabled = false;
                playerCameras[playerPointer - 1].SetActive(false);
                playersToSwitch[playerPointer].enabled = true;
                playerCameras[playerPointer].SetActive(true);
                playersToSwitch[playerPointer + 1].enabled = false;
                playerCameras[playerPointer + 1].SetActive(false);
                break;
             case 2:
                playersToSwitch[playerPointer - 2].enabled = false;
                playerCameras[playerPointer - 2].SetActive(false);
                playersToSwitch[playerPointer - 1].enabled = false;
                playerCameras[playerPointer - 1].SetActive(false);
                playersToSwitch[playerPointer].enabled = true;
                playerCameras[playerPointer].SetActive(true);
                break;

            }
    }
    
    
}
