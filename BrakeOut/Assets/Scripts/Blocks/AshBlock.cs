using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshBlock : Blocks
{
    void Start()
    {
        // 1. Vida base para Medium (4 golpes)
        Durability = 4;

        // 2. Ajuste por dificultad
        if (options_SO != null)
        {
            if (options_SO.Difficultylevel == Options.difficulty.easy)
            {
                // Cambiamos a 1 para que sea un solo golpe real
                Durability = 1; 
            }
            else if (options_SO.Difficultylevel == Options.difficulty.hard)
            {
                Durability = 6; // En difícil será un reto de 6 golpes
            }
        }
    }
}