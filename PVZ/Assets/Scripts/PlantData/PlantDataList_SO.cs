using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlantDataList_SO", menuName = "Plant/PlantDataList")]
public class PlantDataList_SO : ScriptableObject 
{ 
    public List<PlantData_SO> plantDataList = new List<PlantData_SO>();
    public PlantData_SO GetInventoryItem(int ID)
    {
        return plantDataList.Find(i => i.plantID == ID);
    }
    public void PlantAttackAdd(int num)
    {
        for(int i = 0; i < plantDataList.Count; i++)
        {
            plantDataList[i].plantAttack += num;
        }
    }
    public void PlantCDAdd(float cd)
    {
        for (int i = 0; i < plantDataList.Count; i++)
        {
            plantDataList[i].plantCD +=cd;
        }
    }

    public void Init()
    {
        for (int i = 0; i < plantDataList.Count; i++)
        {
            plantDataList[i].plantAttack = plantDataList[i].initPlantAttack;
            plantDataList[i].plantCD = plantDataList[i].initPlantCD;
            plantDataList[i].canUseNum = 0;
        }
    }
    public void CanUseNumADD()
    {
        for (int i = 0; i < plantDataList.Count; i++)
        {
            plantDataList[i].canUseNum += 1 ;
          
        }
    }
}
