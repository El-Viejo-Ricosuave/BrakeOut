using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowEvents : MonoBehaviour
{
    public UnityEvent MyUnityEvent;
    public event EventHandler OnSpacePressed;

    void Start()
    {
        OnSpacePressed += EventRetrieved;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
            MyUnityEvent.Invoke();
        }
    }

    public void EventRetrieved(object sender, EventArgs e)
    {
        Debug.Log("el Evento se escucho correctamente");
    }

    public void UnityEventSent() 
    {

    }
}
