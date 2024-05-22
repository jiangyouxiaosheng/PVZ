using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantChooseUI : MonoBehaviour
{
    public PlantDataList_SO PlantDataList_SO;
    public GameObject plantSlot;
    public Transform UIpos;
    public Button isCanStart;
    void Start()
    {
        for(int i = 0; i < PlantDataList_SO.plantDataList.Count; i++)
        {
            GameObject plant = Instantiate(plantSlot, UIpos);
            plant.GetComponent<PlantSlotChoose>().SetSlotInformation(PlantDataList_SO.plantDataList[i].plantID);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
