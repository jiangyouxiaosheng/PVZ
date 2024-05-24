using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour
{
    [SerializeField]
    private Image plantImage;
    [SerializeField]
    private TextMeshProUGUI plantNeedSun;
    [SerializeField]
    private Image plantCDImage;
    private float plantMaxCD;
    private float plantCurrentCD;
    //为了赶工期临时加的变量，直接给id赋值
    public int plantID;

    public PlantDataList_SO plantDatalist;
    public PlantData_SO plantData;
    public InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

    private void Start()
    {
        plantData = plantDatalist.GetInventoryItem(plantID);
        SetSlotInformation(plantID);

    }

    private void Update()
    {
       
    }

    public void FollowMoustEvent()
    {
     
        if(plantData.plantID != 1003)
        {
            MapCreate.Instance.MapTrue();
        }
       
        inventoryUI.drawImage.GetComponent<DrawPlantImage>().FollowMousePos(plantID);
    }
 

    public void SetSlotInformation(int ID)
    {
        this.plantImage.sprite = plantData.plantImage;
        this.plantNeedSun.text = plantData.plantNeedSun.ToString();
        this.plantMaxCD = plantData.plantCD;
    }
  
   
}
