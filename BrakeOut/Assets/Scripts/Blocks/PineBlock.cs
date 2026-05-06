using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Al heredar de Blocks, ya tiene todo lo necesario automáticamente
public class PineBlock : Blocks
{
    // Solo dejamos el Start para configurar su vida inicial
    void Start()
    {
        Durability = 2; // O la vida que quieras que tenga el pino en Normal

        if (options_SO != null)
        {
            if (options_SO.Difficultylevel == Options.difficulty.easy)
            {
                Durability = 1;
            }
            else if (options_SO.Difficultylevel == Options.difficulty.hard)
            {
                Durability = 4;
            }
        }
    }
}