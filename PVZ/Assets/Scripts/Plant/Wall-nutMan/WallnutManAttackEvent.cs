using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutManAttackEvent : MonoBehaviour
{
   private WallnutMan wallnutMan => GetComponentInParent<WallnutMan>();
   

    public void Ataack()
    {
        wallnutMan.Attack();
        wallnutMan.waitAttackTime = 1;
    }
}
