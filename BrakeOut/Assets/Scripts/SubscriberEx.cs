using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberEx : MonoBehaviour
{
    ShowEvents Subscriber;

    void Start()
    {
        Subscriber = GetComponent<ShowEvents> ();
        Subscriber.OnSpacePressed += MessageRetrievedBySubscriber;
    }

    void Update()
    {
        
    }

    private void MessageRetrievedBySubscriber(object sender, EventArgs e) 
    {
        Debug.Log(" the Event was retrieved from another class");
        Subscriber.OnSpacePressed -= MessageRetrievedBySubscriber;

    }


}
