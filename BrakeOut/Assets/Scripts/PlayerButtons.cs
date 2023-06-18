using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    [SerializeField] public float Movementspeedx = 55f;
    [SerializeField] public int Limitx = 24;
    Transform transform;
    

    void Start() 
    {
        transform = this.gameObject.transform;
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * Movementspeedx * Time.deltaTime);

        Vector3 pos = this.transform.position;
        if (pos.x < -Limitx)
        {
            pos.x = -Limitx;
        }
        else if (pos.x > Limitx) 
        {
            pos.x = Limitx;
        }
        transform.position = pos;
    }
}
