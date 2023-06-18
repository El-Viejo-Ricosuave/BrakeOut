using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    bool isGameStarted = false;
    [SerializeField] public float AmmoSpeed = 22.2f;

    void Start()
    {
        Vector3 initialposition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialposition.y += 2;
        this.transform.position = initialposition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) ||Input.GetButton("Submit")) 
        {
            if (!isGameStarted) 
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = AmmoSpeed * Vector3.up;
            }
        }
    }
}
