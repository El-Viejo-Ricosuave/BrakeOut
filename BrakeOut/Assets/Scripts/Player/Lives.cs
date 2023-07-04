using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [HideInInspector] public List<GameObject> lives;
    public GameObject AmmoPrefab;
    private Ammo Ammoscript;
    public GameObject GameOver;

    void Start () 
    {
        Transform[] Sons = GetComponentsInChildren<Transform>();
        foreach (Transform Son in Sons) 
        {
            lives.Add(Son.gameObject);
        }
        lives.Remove(this.gameObject);
    }

    public void RemoveLifeBar () 
    {
         var ObjectToRemove = lives[lives.Count - 1];
        Destroy(ObjectToRemove);
        lives.RemoveAt(lives.Count - 1);
        if (lives.Count <= 0) 
        {
            GameOver.SetActive(true);
            return;
        }

        var ammo = Instantiate (AmmoPrefab) as GameObject;
        Ammoscript = ammo.GetComponent<Ammo>();
        Ammoscript.DestroyedAmmo.AddListener(this.RemoveLifeBar);
        Debug.Log($"Remaining Lives: {lives.Count}");

    }



}
