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

    void Start()
    {
        // Ajuste de resistencia inicial según la dificultad elegida
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

    // Evento de colisión principal (Física 3D)
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo")) 
        {
            BounceBall(collision);
        }
    }

    // Lógica de rebote y daño
    public virtual void BounceBall(Collision collision)
    {
        Ammo scriptBola = collision.gameObject.GetComponent<Ammo>();
        
        if (scriptBola != null)
        {
            // Calculamos dirección: Punto de impacto menos posición del centro del bloque
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            
            // Aplicamos la velocidad original de la bola en la nueva dirección
            if (collision.rigidbody != null)
            {
                collision.rigidbody.velocity = direction * scriptBola.AmmoSpeed;
            }
        }
        
        // --- TRUCO PARA MODO FÁCIL ---
        if (options_SO != null && options_SO.Difficultylevel == Options.difficulty.easy)
        {
            Durability = 0; // Muerte instantánea
        }
        else
        {
            Durability--; // Restar vida normal
        }
    }

    void Update()
    {
        // Revisar si el bloque debe ser destruido
        if (Durability <= 0)
        {
            Scoring.Invoke();
            Destroy(this.gameObject);
        }
    }
}