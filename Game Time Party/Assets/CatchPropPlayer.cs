using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum AnimStates { MOVING,PICKING }
public class CatchPropPlayer : MonoBehaviour
{
    //[SerializeField] List<Collider> playersToGet = new List<Collider>();

    [SerializeField] Transform[] playerHands;
    //[SerializeField] Camera gameMasterCam;
    [SerializeField] float getRange;
    [SerializeField] LayerMask propPlayerLayer;
    RaycastHit hit;
    bool pickUp, hasClicked;
    [SerializeField] Animator anim;

    [SerializeField] PlayerScores gameMasterScore;

    [SerializeField] Pooling effectPooling;
    // Start is called before the first frame update
    float clickCountdown = 0;
    void Awake()
    {
        anim = GetComponent<Animator>();
        gameMasterScore = GetComponent<PlayerScores>();
    }
    void DetectPropPlayer()
    {
        foreach (Transform hand in playerHands)
        {
            pickUp = Physics.Raycast(hand.position, hand.forward, out hit, getRange, propPlayerLayer);
            if (pickUp)
            {
                //print("Hitted:" + hit.transform.name);
                bool isAPlayer = hit.transform.CompareTag("PropPlayer");
                if (isAPlayer)
                {
                    hit.transform.gameObject.SetActive(false);
                    PropHuntManager.numeroDePlayersPegos += 1;
                    gameMasterScore.ThisPlayerScore += 25;
                    //print("Player Detected. Adding up " + ScoreManager.Instance.pontuacaoGeral + "points to the GameMaster");
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
    }

    // Update is called once per frame
    void Update()
    {      
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.KeypadEnter)) && !hasClicked)
        {
            DetectPropPlayer();
            //print(hasClicked);
            hasClicked = true;
            //Debug.DrawRay(playerHands.position, playerHands.transform.forward * hit.distance, Color.red);
            clickCountdown = anim.GetCurrentAnimatorStateInfo(0).length;
            print(clickCountdown);
        }
        if (hasClicked)
        {
            clickCountdown -= Time.deltaTime;
            anim.SetBool("Pick", true);
        }
        else
        {
            anim.SetBool("Pick", false);
        }
        if (clickCountdown <= 0)
        {
            hasClicked = false;
            clickCountdown = 0;
        }


    }
}
