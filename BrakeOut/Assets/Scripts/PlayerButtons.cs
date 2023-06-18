using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    [SerializeField] public int LimitX = 24;
    [SerializeField] public float PlayerSpeed = 66.6f;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") *Vector3.down * PlayerSpeed * Time.deltaTime);

        Vector3 pos = this.transform.position;
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
