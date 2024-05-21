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


    public PlantDataList_SO plantDatalist;
    public PlantData_SO plantData;
    public InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

    private void Start()
    {
        SetSlotInformation(1001);


    }

    private void Update()
    {
       
    }

    public void FollowMoustEvent()
    {
        MapCreate.Instance.MapTrue();
        inventoryUI.drawImage.GetComponent<DrawPlantImage>().FollowMousePos(plantData.plantID);
    }
 

    public void SetSlotInformation(int ID)
    {
        plantData = plantDatalist.GetInventoryItem(ID);
        this.plantImage.sprite = plantData.plantImage;
        this.plantNeedSun.text = plantData.plantNeedSun.ToString();
        this.plantMaxCD = plantData.plantCD;
    }
  
   
}
