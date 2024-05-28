using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Spine;

public class PlantAttributeManagement : MonoBehaviour
{
   
    [SerializeField]
    public PlantData_SO plantData_S0;
    public PlantData plantData = new PlantData();
    public PlantDataList_SO plantDataList;
    private Transform plantParents;
    public int plantAttack;
    public bool isDoubleShooter;
    public bool isNowDie;
    public bool isPumpkin;
    private void Start()
    {
       
        plantParents = GameObject.Find("PlantsParent").transform;
        plantData.Init(plantData_S0);
    }
    private void Update()
    {
        plantAttack = plantData.plantAttack;
    }
    public void PlantIsInjury(int damage)
    {
        Debug.Log(plantData.plantName + "’˝‘⁄ ‹…À");
        plantData.plantHp -= damage;
        Debug.LogError(plantData.plantHp); 
        if(plantData.plantHp <= 0)
        {
            if (isNowDie)
            {
                SetDestroyplantMap();
            }
            if (isPumpkin)
            {
                SetDestroyPumpkinMap();
            }
           
        }
    }
    public void SetDestroyplantMap()
    {
        MapSquareCreatPlant mapS = MapCreate.Instance.destroyPlant[gameObject].GetComponent<MapSquareCreatPlant>();
        mapS.DestroyPlant();
        MapCreate.Instance.destroyPlant.Remove(gameObject);
       // GameManager.Instance.plantList.Remove(gameObject);
        Destroy(gameObject);
    }

    public void SetDestroyPumpkinMap()
    {
        MapSquareCreatPlant mapS = MapCreate.Instance.destroyPumkin[gameObject].GetComponent<MapSquareCreatPlant>();
        mapS.DestroyPumpkin();
        MapCreate.Instance.destroyPumkin.Remove(gameObject);
       // GameManager.Instance.plantList.Remove(gameObject);
        Destroy(gameObject);
    }

    public void SetGatlingPea(GameObject slot)
    {
        if (isDoubleShooter)
        {
            
            MapSquareCreatPlant mapS = MapCreate.Instance.destroyPlant[gameObject].GetComponent<MapSquareCreatPlant>();
            GameObject obj = Instantiate(plantDataList.GetInventoryItem(1003).plantPrefabs);
            obj.transform.SetParent(plantParents);
            obj.transform.position = transform.position;
            MapCreate.Instance.destroyPlant.Remove(gameObject);
           // GameManager.Instance.plantList.Remove(gameObject);
            MapCreate.Instance.destroyPlant.Add(obj, mapS.gameObject);
           // GameManager.Instance.plantList.Add(gameObject);
            Destroy(gameObject);
        }

    }


}
