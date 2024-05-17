using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlantData_SO", menuName = "Plant/PlantData")]
public class PlantData_SO : ScriptableObject
{
    public int plantID;
    public string plantName;
    public Image plantImage;
    public int plantHp;
    public float plantAttackSpeed;
    public int plantNeedSun;
    public bool plantSleep;



}
