using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
    [SerializeField] Transform playerFeet;
    //Mesh meshCollider;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
        myCollider = GetComponent<Collider>();
        myMat = GetComponent<Renderer>().material;
        characterMovement = GetComponent<CharacterMovement>();
        playerScores = GetComponent<PlayerScores>();
        playerScores.ThisPlayerScore = 25;
    }

    void DetectProps()
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
                //print("Prop Detected");
                GetComponent<MeshFilter>().sharedMesh = propMesh;
                GetComponent<Renderer>().material = propMat;
                //SetMaterialProperties(propMat);
                myCollider = prop;
                meshCollider.sharedMesh = propMesh;
                
            }
        }
    }
    void SetMaterialProperties(Material objMat)
    {
        myMat.SetColor("_Color", objMat.color);
        myMat.mainTexture = objMat.mainTexture;
    }
    void Update()
    {
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
