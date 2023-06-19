using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAdmin : MonoBehaviour
{
    public List<PersistentScore> ObjectToSave;

    public void OnEnable() 
    {
        for (int i = 0; i < ObjectToSave.Count; i++) 
        {
            var so = ObjectToSave[i];
            so.Load();
        }
    }
    
}
