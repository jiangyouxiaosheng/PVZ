using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlantAttributeManagement : MonoBehaviour
{
   
    [SerializeField]
    public PlantData_SO plantData_S0;
    public PlantData plantData = new PlantData();
    public PlantDataList_SO plantDataList;
    private Transform plantParents;
    public bool isDoubleShooter;
    private void Start()
    {
        plantParents = GameObject.Find("PlantsParent").transform;
        plantData.Init(plantData_S0);
    }
    public void PlantIsInjury(int damage)
    {
        Debug.Log(plantData.plantName + "’˝‘⁄ ‹…À");
        plantData.plantHp -= damage;
        Debug.LogError(plantData.plantHp); 
        if(plantData.plantHp <= 0)
        {
           // Destroy(gameObject);
        }
    }
    public void SetDestroyplantMap()
    {
        MapSquareCreatPlant mapS = MapCreate.Instance.destroyPlant[gameObject].GetComponent<MapSquareCreatPlant>();
        mapS.DestroyPlant();
        MapCreate.Instance.destroyPlant.Remove(gameObject);
        Destroy(gameObject);
    }

    public void SetGatlingPea()
    {
        if (isDoubleShooter)
        {
            MapSquareCreatPlant mapS = MapCreate.Instance.destroyPlant[gameObject].GetComponent<MapSquareCreatPlant>();
            GameObject obj = Instantiate(plantDataList.GetInventoryItem(1003).plantPrefabs);
            obj.transform.SetParent(plantParents);
            obj.transform.position = transform.position;
            MapCreate.Instance.destroyPlant.Remove(gameObject);
            MapCreate.Instance.destroyPlant.Add(obj, mapS.gameObject);
            Destroy(gameObject);
        }

    }


}
