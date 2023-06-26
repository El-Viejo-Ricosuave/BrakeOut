using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineBlock : Blocks
{
    void Start()
    {
        Durability = 1;
    }

   public override void BounceBall(Collision collision) 
   {
        base.BounceBall(collision);
        
   }

}
