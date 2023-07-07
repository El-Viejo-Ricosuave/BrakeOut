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
    Rigidbody rigidbody;
    private BorderControl control;
    public UnityEvent DestroyedAmmo;

    private void Awake() 
    {
        control = GetComponent<BorderControl> ();
    }

    void Start()
    {
        isGameStarted = false;
        Vector3 initialposition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialposition.y += 2f;
        this.transform.position = initialposition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (control.OutDown) 
        {
            DestroyedAmmo.Invoke();
            Destroy(this.gameObject);
        }
        if (control.OutUp) 
        {
            direction = transform.position - LastPosition;
            Debug.Log("Ammo Has touched the upper border");
            direction.y *= -1;
            direction = direction.normalized;  
            rigidbody.velocity = AmmoSpeed * direction;
            control.OutUp = false;
            control.enabled = false;
            Invoke("EnableControl", 0.1f);
        }

        if (control.OutRight)
        {
            direction = transform.position - LastPosition;
            Debug.Log("Ammo Has touched the Right border");
             direction.x *= -1;
            direction = direction.normalized;
            rigidbody.velocity = AmmoSpeed * direction;
            control.OutRight = false;
            control.enabled = false;
            Invoke("EnableControl", 0.1f);
        }

        if (control.OutLeft)
        {
            direction = transform.position - LastPosition;
            Debug.Log("Ammo Has touched the Left border");
             direction.x *= -1;
            direction = direction.normalized;
            rigidbody.velocity = AmmoSpeed * direction;
            control.OutLeft = false;
            control.enabled = false;
            Invoke("EnableControl", 0.1f);
        }

        if (Input.GetKey(KeyCode.Space) ||Input.GetButton("Submit")) 
        {
            if (!isGameStarted) 
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = AmmoSpeed * Vector3.up;
            }
        }
    }

    private void EnableControl() 
    {
        control.enabled = true;
    }

    void FixedUpdate() 
    {
        LastPosition = transform.position;
    }

    void LateUpdate() 
    {
        if (direction != Vector3.zero) direction = Vector3.zero;
    }

}
