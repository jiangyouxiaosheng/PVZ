using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doom : MonoBehaviour
{
    public PlantAttributeManagement attributeManagement;
    float timer = 1f;
    private void Awake()
    {
        attributeManagement = GetComponent<PlantAttributeManagement>();

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            ZombieManager.Instance.AllZombieDamage();
          //  UIManager.Instance.inventoryUI.IceAnimation();
            attributeManagement.SetDestroyplantMap();

        }

    }
}
