using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int LimitX = 24;
    [SerializeField] public float PlayerSpeed = 66.6f;
    Vector3 Mousepos2D;
    Vector3 Mousepos3D;

    void Update() 
    {
        Mousepos2D = Input.mousePosition;
        Mousepos2D.z = -Camera.main.transform.position.z;
        Mousepos3D = Camera.main.ScreenToWorldPoint(Mousepos2D);

        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(Vector3.up * PlayerSpeed *Time.deltaTime);  
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.down * PlayerSpeed * Time.deltaTime);

        }

        Vector3 pos = this.transform.position;
        //pos.x = Mousepos3D.x;

        if (pos.x < -LimitX) 
        {
            pos.x = -LimitX;

        }
        else if (pos.x > LimitX) 
        {
            pos.x = LimitX;
        }
        this.transform.position = pos;

    }

}
