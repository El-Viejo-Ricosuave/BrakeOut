using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    bool isGameStarted;
    [SerializeField] public float AmmoSpeed = 22.2f; 
    Vector3 LastPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    
    new Rigidbody rigidbody; 
    
    private BorderControl control;
    public UnityEvent DestroyedAmmo;
    public Options options_SO;

    private void Awake() 
    {
        control = GetComponent<BorderControl>();
        rigidbody = GetComponent<Rigidbody>(); 

        if (options_SO == null)
        {
            // Salvavidas para encontrar el cubo azul
            Options[] allOptions = Resources.FindObjectsOfTypeAll<Options>();
            if(allOptions.Length > 0) {
                options_SO = allOptions[0];
                Debug.Log("Opciones encontradas automáticamente.");
            } else {
                Debug.LogError("¡CUIDADO! No se encontró el archivo de Opciones.");
            }
        }

        // Importante: fricción a cero para que no se frene sola
        rigidbody.drag = 0;
        rigidbody.angularDrag = 0;
    }

    void Start()
    {
        isGameStarted = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 initialposition = player.transform.position;
            initialposition.y += 2f;
            this.transform.position = initialposition;
            this.transform.SetParent(player.transform);
        }
    }

    void Update()
    {
        if (control.OutDown) 
        {
            DestroyedAmmo.Invoke();
            Destroy(this.gameObject);
            return; 
        }

        CheckBorders();

        // Cambié a GetKeyDown para que solo detecte el primer toque y no se bugee si dejas picado
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit")) 
        {
            if (!isGameStarted) 
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                
                if (options_SO != null)
                {
                    AmmoSpeed = options_SO.AmmoSpeed; 
                }

                rigidbody.velocity = AmmoSpeed * Vector3.up; 
                Debug.Log("Bola lanzada a: " + AmmoSpeed);
            }
        }
    }

    private void CheckBorders()
    {
        if (control.OutUp || control.OutRight || control.OutLeft)
        {
            direction = transform.position - LastPosition;
            
            if (control.OutUp) direction.y *= -1;
            if (control.OutRight || control.OutLeft) direction.x *= -1;

            direction = direction.normalized;  
            
            if (options_SO != null)
            {
                AmmoSpeed = options_SO.AmmoSpeed; 
            }

            rigidbody.velocity = AmmoSpeed * direction;

            control.OutUp = false;
            control.OutRight = false;
            control.OutLeft = false;
            control.enabled = false;
            Invoke("EnableControl", 0.1f);
        }
    }

    private void EnableControl() 
    {
        control.enabled = true;
    }

    void FixedUpdate() 
    {
        LastPosition = transform.position;

        // --- EL SEGURO DE VELOCIDAD ---
        // Si el juego empezó, obligamos a la bola a mantener SIEMPRE la velocidad del slider
        if (isGameStarted && rigidbody.velocity.magnitude > 0)
        {
            // Si el SO existe, actualizamos AmmoSpeed por si moviste el slider en pausa
            if (options_SO != null) AmmoSpeed = options_SO.AmmoSpeed;

            // Mantenemos la dirección pero forzamos la magnitud a ser AmmoSpeed
            rigidbody.velocity = rigidbody.velocity.normalized * AmmoSpeed;
        }
    }

    void LateUpdate() 
    {
        if (direction != Vector3.zero) direction = Vector3.zero;
    }
}