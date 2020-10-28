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
    //RaycastHit hit;
    bool hasClicked;
    Collider[] pickUp;
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
            do
            {
                pickUp = Physics.OverlapSphere(hand.position, getRange, propPlayerLayer);
                foreach (Collider picks in pickUp)
                {
                    print("Hitted:" + picks.transform.name);
                    bool isAPlayer = picks.transform.CompareTag("PropPlayer");
                    if (isAPlayer)
                    {
                        picks.transform.gameObject.SetActive(false);
                        PropHuntManager.numeroDePlayersPegos += 1;
                        gameMasterScore.ThisPlayerScore += 25;
                        //print("Player Detected. Adding up " + ScoreManager.Instance.pontuacaoGeral + "points to the GameMaster");
                        GameObject aux = effectPooling.GetPooledObject();
                        if (aux != null)
                        {
                            aux.transform.position = picks.transform.position;
                            aux.transform.rotation = picks.transform.rotation;
                            aux.SetActive(true);
                        }
                    }
                    else
                    {
                        print("Not a Player");
                        // return;
                    }
                }
            } while (clickCountdown >= 0.5f);
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
            clickCountdown = anim.GetCurrentAnimatorStateInfo(0).length + 0.3f;
            //print(clickCountdown);
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
    private void OnDrawGizmosSelected()
    {
        foreach (Transform item in playerHands)
        {
            Gizmos.DrawWireSphere(item.position, getRange);
        }
    }
}
