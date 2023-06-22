using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public int Durability = 1;
    public UnityEvent Scoring;
    
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
        Durability--;
    }


}
