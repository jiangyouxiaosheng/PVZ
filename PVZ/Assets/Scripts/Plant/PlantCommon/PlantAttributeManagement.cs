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
    private AudioSource _audioSource=> GetComponent<AudioSource>();
    private void Start()
    {
        _audioSource.Play();
        plantParents = GameObject.Find("PlantsParent").transform;
        plantData.Init(plantData_S0);
    }
    private void Update()
    {
        plantAttack = plantData_S0.plantAttack;
    }
    public void PlantIsInjury(int damage)
    {
        Debug.Log(plantData.plantName + "’˝‘⁄ ‹…À");
        plantData.plantHp -= damage;
        Debug.Log(plantData.plantHp);
        if(plantData.plantHp <= 0)
        {
            VoiceManager.Instance.Eat();
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
        Destroy(gameObject);
    }

    public void SetDestroyPumpkinMap()
    {
        MapSquareCreatPlant mapS = MapCreate.Instance.destroyPumkin[gameObject].GetComponent<MapSquareCreatPlant>();
        mapS.DestroyPumpkin();
        MapCreate.Instance.destroyPumkin.Remove(gameObject);

        Destroy(gameObject);
    }

    public void SetGatlingPea(GameObject slot)
    {
        if (isDoubleShooter)
        {
            slot.GetComponent<PlantSlot>().ResetCd();
            SunManager.Instance.SunDown(plantData.plantNeedSun);
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
