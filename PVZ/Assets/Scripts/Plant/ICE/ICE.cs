using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ICE : MonoBehaviour
{

    public PlantAttributeManagement attributeManagement;
    float timer = 1f;
    private void Awake()
    {
        attributeManagement = GetComponent<PlantAttributeManagement>();
     
    }

    private void Update()
    {
        timer -=Time.deltaTime;
        if(timer < 0f)
        {
            ZombieManager.Instance.AllZombieStop();
            attributeManagement.SetDestroyplantMap();
           
        }
        
    }
}
