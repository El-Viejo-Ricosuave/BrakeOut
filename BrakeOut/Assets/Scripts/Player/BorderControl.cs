using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    [Header("Configure in Editor")]
    public float radio = 1f;
    public bool KeepOnScreen = false;

    [Header("Dinamic Settings")]
    public bool OnScreen = true;
    public float CameraWidth;
    public float CameraHeight;
    public bool OutRight, OutLeft, OutUp,OutDown;

    public void Awake()
    {
        CameraHeight = Camera.main.orthographicSize;
        CameraWidth = Camera.main.aspect * CameraHeight;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        OnScreen = true;
        OutDown = OutUp = OutRight = OutLeft = false;
        if (pos.x > CameraWidth - radio) 
        {
            pos.x = CameraWidth - radio;
            OutRight = true;
        }
        if (pos.x < -CameraWidth + radio) 
        {
            pos.x = -CameraWidth + radio;
            OutLeft = true; 
        }
        if (pos.y > CameraHeight - radio) 
        {
            pos.y = CameraWidth - radio;
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
        if (!Application.isPlaying) return;
        Vector3 BorderSize = new Vector3(CameraWidth * 2, CameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, BorderSize); 
    }
      



}
