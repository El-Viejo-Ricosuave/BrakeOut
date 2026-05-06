using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blocks : MonoBehaviour
{
    [Header("Configuración de Bloque")]
    public int Durability = 1;
    public UnityEvent Scoring;
    
    [Header("Referencia a Dificultad")]
    public Options options_SO;

    protected virtual void Start()
    {
        if (options_SO != null)
        {
            if (options_SO.Difficultylevel == Options.difficulty.easy)
            {
                Durability = 1; 
            }
            else if (options_SO.Difficultylevel == Options.difficulty.medium)
            {
                Durability = 2; 
            }
            else if (options_SO.Difficultylevel == Options.difficulty.hard)
            {
                Durability = 3; 
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo")) 
        {
            BounceBall(collision);
        }
    }

    public virtual void BounceBall(Collision collision)
    {
        Ammo scriptBola = collision.gameObject.GetComponent<Ammo>();
        
        if (scriptBola != null)
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            
            if (collision.rigidbody != null)
            {
                collision.rigidbody.velocity = direction * scriptBola.AmmoSpeed;
            }
        }
        
        if (options_SO != null && options_SO.Difficultylevel == Options.difficulty.easy)
        {
            Durability = 0; 
        }
        else
        {
            Durability--; 
        }
    }

    void Update()
    {
        if (Durability <= 0)
        {
            Scoring.Invoke();
            Destroy(this.gameObject);
        }
    }
}