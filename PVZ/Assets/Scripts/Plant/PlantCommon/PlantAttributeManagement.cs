using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlantAttributeManagement : MonoBehaviour
{
    public Dictionary<GameObject,GameObject> destroyPlant = new Dictionary<GameObject,GameObject> ();
    [SerializeField]
    public PlantData_SO plantData_S0;
    public PlantData plantData = new PlantData();



    private void Start()
    {
        plantData.Init(plantData_S0);
    }
    public void PlantIsInjury(int damage)
    {
        Debug.Log(plantData.plantName + "’˝‘⁄ ‹…À");
        plantData.plantHp -= damage;
        Debug.LogError(plantData.plantHp); 
        if(plantData.plantHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetDestroyplantMap()
    {
        MapSquareCreatPlant mapS = destroyPlant[gameObject].GetComponent<MapSquareCreatPlant>();
        mapS.DestroyPlant();
        destroyPlant.Remove(gameObject);
        Destroy(gameObject);
    }


}
