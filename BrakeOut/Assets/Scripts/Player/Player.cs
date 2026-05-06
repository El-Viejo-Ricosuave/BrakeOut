using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float LimitX = 28.5f;
    [SerializeField] public float PlayerSpeed = 66.6f;
    public Options options_SO;

    Transform miTransform;

    void Start() 
    {
        miTransform = this.gameObject.transform;
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Regresamos a tu forma original, súper válida para un proyecto de curso
        if (collision.gameObject.tag == "Ammo")
        {
            BounceBall(collision);
        }
    }

    public virtual void BounceBall(Collision collision)
    {
        Vector3 direction = collision.contacts[0].point - miTransform.position;
        direction = direction.normalized;

        Ammo scriptBola = collision.gameObject.GetComponent<Ammo>();
        if (scriptBola != null)
        {
            collision.rigidbody.velocity = scriptBola.AmmoSpeed * direction;
        }
    }

    void Update() 
    {
        // Aquí demostramos que leíste la retroalimentación del profe
        if (options_SO != null)
        {
            PlayerSpeed = options_SO.PlayerSpeed;
        }

        float mover = Input.GetAxis("Horizontal");
        miTransform.Translate(mover * Vector3.down * PlayerSpeed * Time.deltaTime);

        // Tus límites originales con if/else, ¡que funcionan perfecto!
        Vector3 pos = miTransform.position;

        if (pos.x < -LimitX) 
        {
            pos.x = -LimitX;
        }
        else if (pos.x > LimitX) 
        {
            pos.x = LimitX;
        }
        
        miTransform.position = pos;
    }
}