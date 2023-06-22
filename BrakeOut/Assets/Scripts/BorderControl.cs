using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    [Header("Configure in editor")]
    public float radio = 1f;
    public bool KeepOnScreen = false;

    [Header("Dinamic Settings")]
    public bool OnScreen = true;
    public float CameraWith;
    public float CameraHeight;
    public bool OutRight, OutLeft, OutUp,OutDown;

    public void Awake()
    {
        CameraHeight = Camera.main.orthographicSize;
        CameraWith = Camera.main.aspect * CameraHeight;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        OnScreen = true;
        OutDown = OutUp = OutRight = OutLeft = false;
        if (pos.x > CameraWith - radio) 
        {
            pos.x = CameraWith - radio;
            OutRight = true;
        }
        if (pos.x < -CameraWith + radio) 
        {
            pos.x = -CameraWith + radio;
            OutLeft = true; 
        }
        if (pos.y > CameraHeight - radio) 
        {
            pos.y = CameraHeight - radio;
            OutUp = true;
        }  
        if(pos.y < -CameraHeight + radio) 
        { 
            pos.y = -CameraHeight + radio;
        }

        OnScreen =!(OutDown||OutUp||OutLeft||OutRight);

        if (KeepOnScreen && !OnScreen)
        { 
            transform.position = pos;
            OnScreen = true;
        }
    }
    private void OnDrawGizmos() 
    {
        if (Application.isPlaying) return;
        Vector3 Bordersize = new Vector3(CameraWith * 2, CameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, Bordersize); 
    }
      



}
