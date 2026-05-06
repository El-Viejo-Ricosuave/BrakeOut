using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlocks : MonoBehaviour
{
    private float Activate = 4.0f;
    private float Deactivate = 2.0f;
    public float timer = 0.0f;
    
    private MeshRenderer blockMesh;
    private BoxCollider blockCollider;

    void Start()
    {
        // 1. Buscamos los componentes UNA SOLA VEZ al iniciar el nivel
        blockMesh = GetComponent<MeshRenderer>();
        blockCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // El reloj sigue avanzando
        timer += Time.deltaTime;

        // Si el tiempo llega a 4 segundos, lo prendemos y reiniciamos el reloj
        if (timer >= Activate) 
        {
            timer = 0.0f;
            
            // Solo lo prendemos si estaba apagado
            if (!blockMesh.enabled)
            {
                blockMesh.enabled = true;
                blockCollider.enabled = true;
            }
        }
        // Si el tiempo pasa de 2 segundos (pero aún no llega a 4), lo apagamos
        else if (timer >= Deactivate) 
        {
            // Solo lo apagamos si estaba prendido
            if (blockMesh.enabled)
            {
                blockMesh.enabled = false;
                blockCollider.enabled = false;
            }
        }
    }
}