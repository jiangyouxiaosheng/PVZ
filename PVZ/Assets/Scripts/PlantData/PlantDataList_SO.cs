using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlantDataList_SO", menuName = "Plant/PlantDataList")]
public class PlantDataList_SO : ScriptableObject 
{ 
    public List<PlantData_SO> plantDataList = new List<PlantData_SO>();
}
