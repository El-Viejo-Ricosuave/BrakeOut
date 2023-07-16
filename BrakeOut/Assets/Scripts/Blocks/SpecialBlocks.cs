using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlocks : MonoBehaviour
{
    private float Activate = 4.0F;
    private float Deactivate = 2.0f;
    private bool IsOff = false;
    private bool IsOn = false; 
    public float timer = 0.0f;
    private MeshRenderer Mesh;
    private BoxCollider collider;

    void Update()
    {
        timer += Time.deltaTime;
        Mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();

        if (timer > Deactivate & IsOff == false) 
        {
            Mesh.enabled = false;
            collider.enabled = false;
        }
        if (timer > Activate & IsOn == false) 
        {
            timer = 0.0f;
            Mesh.enabled = true;
            collider.enabled = true;
        }
    }
}
