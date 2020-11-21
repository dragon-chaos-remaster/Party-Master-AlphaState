using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Cinemachine;
public class MeshChanger : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int triangulos;

    Material myMat;
    Collider myCollider;
    [SerializeField] float propDetectionRadius = 3f;
    [SerializeField] Collider[] activeProps;
    [SerializeField] LayerMask propsLayer;
    [SerializeField] PlayerScores playerScores;
    CharacterMovement characterMovement;
    [SerializeField] Transform playerFeet, cameraLookAtCenter;

    [SerializeField] Pooling transformEffect;
    bool effectActivated, pickedUpProp;
    float countdown = 1.5f, aux = 0;
    [SerializeField] ParentChildrenListing listaDeBones;
    [SerializeField] CinemachineFreeLook playerCamera;

    public bool PickedUpProp => pickedUpProp;
    //Mesh meshCollider;
    void Start()
    {
        aux = countdown;
        mesh = GetComponent<MeshFilter>().sharedMesh;
        myCollider = GetComponent<Collider>();
        myMat = GetComponent<Renderer>().material;
        characterMovement = GetComponent<CharacterMovement>();
        playerScores = GetComponent<PlayerScores>();
        playerScores.ThisPlayerScore = 25;
    }

    public void DetectProps()
    {
        activeProps = Physics.OverlapSphere(transform.position, propDetectionRadius, propsLayer);
        foreach (Collider prop in activeProps)
        {

            Mesh auxMesh = prop.GetComponent<MeshFilter>().sharedMesh;
            Material propMat = prop.GetComponent<Renderer>().sharedMaterial;
            Mesh propMesh = Instantiate(auxMesh,playerFeet.position,Quaternion.identity);
            
            MeshCollider meshCollider = GetComponent<MeshCollider>();
            if (prop != null)
            {
                listaDeBones.DeactivateParent();
                //print("Prop Detected");
                playerCamera.Follow = playerFeet;
                playerCamera.LookAt = cameraLookAtCenter;
                GetComponent<MeshFilter>().sharedMesh = propMesh;
                GetComponent<Renderer>().material = propMat;
                GameObject sfx = transformEffect.GetPooledObject();
                if(sfx != null && !effectActivated)
                {
                    sfx.SetActive(true);
                    sfx.transform.position = transform.position;
                    sfx.transform.rotation = transform.rotation;
                    effectActivated = true;
                }
                //SetMaterialProperties(propMat);
                myCollider = prop;
                meshCollider.sharedMesh = propMesh;
                switch (prop.tag)
                {
                    case "EstanteObj":
                        characterMovement.GetCharacterController.height = 18.54f;
                        break;
                    default:
                        characterMovement.GetCharacterController.height = 2f;
                        break;
                }
                if (!pickedUpProp)
                {
                    prop.gameObject.SetActive(false);
                    pickedUpProp = true;
                }               
            }
        }
    }
    public void CountdownFunction()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            StuffHappens();
            countdown = aux;
        }
    }
    void StuffHappens()
    {
        effectActivated = false;
        pickedUpProp = false;
    }
    void SetMaterialProperties(Material objMat)
    {
        myMat.SetColor("_Color", objMat.color);
        myMat.mainTexture = objMat.mainTexture;
    }
    void Update()
    {
        CountdownFunction();
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Fire1"))
        {
            DetectProps();
            //print(myMat);
        }
    }
    private void OnDisable()
    {
        playerScores.ThisPlayerScore *= 0;
    }
    private void OnDrawGizmos()
    {
        float Hue = 1, Saturation = 0.6f, Value = 2;
        Color magenta = Color.magenta;
        Color.RGBToHSV(magenta, out Hue, out Saturation, out Value);
        Gizmos.color = magenta;
        Gizmos.DrawWireSphere(transform.position, propDetectionRadius);      
        //Handles.ConeHandleCap(1,transform.position, Quaternion.identity, propDetectionRadius,EventType.KeyDown);
    }
}
