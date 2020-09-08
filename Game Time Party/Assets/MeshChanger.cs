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

    [SerializeField] Pooling pooling;
    //Mesh meshCollider;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
        myCollider = GetComponent<Collider>();
        myMat = GetComponent<Renderer>().sharedMaterial;
    }

    void DetectProps()
    {
        activeProps = Physics.OverlapSphere(transform.position, propDetectionRadius, propsLayer);
        foreach (Collider prop in activeProps)
        {
            Mesh auxMesh = prop.GetComponent<MeshFilter>().sharedMesh;
            Material propMat = prop.GetComponent<Renderer>().sharedMaterial;
            Mesh propMesh = Instantiate(auxMesh);
            
            MeshCollider meshCollider = GetComponent<MeshCollider>();
            if (prop != null)
            {
                print("Prop Detected");
                GetComponent<MeshFilter>().sharedMesh = propMesh;
                myMat = propMat;
                myCollider = prop;
                meshCollider.sharedMesh = propMesh;
             
            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Fire1"))
        {
            DetectProps();
            GameObject aux = pooling.GetPooledObject();
            if(aux != null)
            {
                aux.transform.position = transform.position;
                aux.transform.rotation = transform.rotation;
                aux.SetActive(true);
            }
        }
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
