using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlotBackGround : MonoBehaviour
{
    public bool isUsed;


    private void Update()
    {
        if(transform.childCount == 0)
        {
            isUsed = false;
        }
    }
}
