using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData 
{
    public int plantID;
    public string plantName;
    public Sprite plantImage;
    public int plantHp;
    public float plantAttackSpeed;
    public int plantNeedSun;
    public bool plantSleep;
    public float plantCD;
    public int plantAttackNum;
    public GameObject plantPrefabs;



    public void Init(PlantData_SO plantData_SO)
    {
        plantID = plantData_SO.plantID;
        plantName = plantData_SO.plantName;
        plantImage = plantData_SO.plantImage;
        plantHp = plantData_SO.plantHp;
        plantAttackSpeed = plantData_SO.plantAttackSpeed;
        plantNeedSun =  plantData_SO.plantNeedSun;
        plantSleep = plantData_SO.plantSleep;
        plantCD = plantData_SO.plantCD;
        plantPrefabs = plantData_SO.plantPrefabs;
        plantAttackNum = plantData_SO.plantAttackNum;
    }
}
