using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MeshChanger : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int triangulos;
    Material mat;

    Collider myCollider;
    [SerializeField] float propDetectionRadius = 3f;
    [SerializeField] Collider[] activeProps;
    [SerializeField] LayerMask propsLayer;
    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().sharedMesh;
        myCollider = GetComponent<Collider>();
    }

    void DetectProps()
    {
        activeProps = Physics.OverlapSphere(transform.position, propDetectionRadius, propsLayer);
        foreach(Collider prop in activeProps)
        {
            Mesh auxMesh = prop.GetComponent<MeshFilter>().sharedMesh;
            Mesh propMesh = Instantiate(auxMesh);
            if(prop != null)
            {
                print("Prop Detected");
                GetComponentInChildren<MeshFilter>().sharedMesh = propMesh;
                myCollider = prop;
            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DetectProps();

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
