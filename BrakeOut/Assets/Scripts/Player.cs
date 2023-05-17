using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float Speed = 0.5f;

    void fixedUpdate()
    {
        var Pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Pos.x += Speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Pos.x -= Speed;
        }
        transform.position = Pos;
    }
}
