using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float LimitX = 28.5f;
    [SerializeField] public float PlayerSpeed = 66.6f;

    Transform transform;
    Vector3 Mousepos2D;
    Vector3 Mousepos3D;

    void Start() 
    {
        transform = this.gameObject.transform;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            BounceBall(collision);
        }
    }

    public virtual void BounceBall(Collision collision)
    {
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ammo>().AmmoSpeed * direction;
    }



    void Update() 
    {
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * PlayerSpeed * Time.deltaTime);

        //Mousepos2D = Input.mousePosition;
        //Mousepos2D.z = -Camera.main.transform.position.z;
        //Mousepos3D = Camera.main.ScreenToWorldPoint(Mousepos2D);

        //if (Input.GetKey(KeyCode.A)) 
        //{
        //    transform.Translate(Vector3.up * PlayerSpeed *Time.deltaTime);  
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.down * PlayerSpeed * Time.deltaTime);

        //}

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
