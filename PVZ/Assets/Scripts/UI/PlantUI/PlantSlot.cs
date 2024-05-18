using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour
{
    [SerializeField]
    private Button plantClick;
    [SerializeField]
    private Image plantImage;
    [SerializeField]
    private TextMeshProUGUI plantNeedSun;
    [SerializeField]
    private Image plantCDImage;
    private float plantMaxCD;
    private float plantCurrentCD;


    public PlantDataList_SO plantDatalist;
    private PlantData_SO plantData;
    public InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

    private void Start()
    {
        SetSlotInformation(001);
      //      plantClick.onClick.AddListener(FollowMoustEvent);
    }

    private void Update()
    {
       
    }

    public void FollowMoustEvent()
    {
        MapCreate.Instance.MapTrue();
        inventoryUI.drawImage.GetComponent<DrawPlantImage>().FollowMousePos();

      
    }
 

    public void SetSlotInformation(int ID)
    {
        plantData = plantDatalist.GetInventoryItem(ID);
        this.plantImage.sprite = plantData.plantImage;
        this.plantNeedSun.text = plantData.plantNeedSun.ToString();
        this.plantMaxCD = plantData.plantCD;
    }
  
   
}
