using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlantChooseUI : MonoBehaviour
{
    public PlantDataList_SO PlantDataList_SO;
    public GameObject plantSlot;
    public GameObject plantSlotBackGround;
    public Transform UIpos;
    public Button isCanStart;
   
    void Start()
    {
        for(int i = 0; i < PlantDataList_SO.plantDataList.Count; i++)
        {

            GameObject plantSlotGround = Instantiate(plantSlotBackGround, UIpos);
            GameObject plant = Instantiate(plantSlot, plantSlotGround.transform);
            UIManager.Instance.plantChooseDir.Add(plant, plantSlotGround.transform);
            plant.GetComponent<PlantSlotChoose>().SetSlotInformation(PlantDataList_SO.plantDataList[i].plantID);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
