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
    [SerializeField]
    private Text plantName;
    [SerializeField]
    private Image plantNameImage;
    private float plantMaxCD;
    public float plantCurrentCD;
    public GameObject needSunImage;
    //为了赶工期临时加的变量，直接给id赋值
    public int plantID;

    public PlantDataList_SO plantDatalist;
    public PlantData_SO plantData;
    public InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

    private void Start()
    {
        plantMaxCD = plantDatalist.GetInventoryItem(plantID).plantCD;
        plantCurrentCD = plantDatalist.GetInventoryItem(plantID).plantCD;
        plantData = plantDatalist.GetInventoryItem(plantID);
        SetSlotInformation(plantID);
        plantName.text = plantDatalist.GetInventoryItem(plantID).plantName;

    }

    private void Update()
    {
        Sun(plantData.plantNeedSun);

        plantCurrentCD -= Time.deltaTime;
        if (plantCurrentCD > 0)
        {
            plantCDImage.gameObject.SetActive(true);
            plantCDImage.fillAmount = plantCurrentCD / plantMaxCD;
        }
        else
        {
            plantCDImage.gameObject.SetActive(false);
            plantCurrentCD = 0;
        }


    }

    public void ResetCd()
    {
        plantCurrentCD = plantMaxCD;
    }
    public void FollowMoustEvent()
    {
        if(plantCurrentCD <= 0 && SunManager.Instance.SunClick(plantData.plantNeedSun))
        {
            if (plantData.plantID != 1003)
            {
                MapCreate.Instance.MapTrue();
            }

            inventoryUI.drawImage.GetComponent<DrawPlantImage>().FollowMousePos(plantID,gameObject);
        }
       
    }
 
    public void Sun(int needSun)
    {
        if(needSun > SunManager.Instance.SunCount())
        {
            needSunImage.SetActive(true);
        }
        else
        {
            needSunImage.SetActive(false);
        }
    }
    public void SetSlotInformation(int ID)
    {
        this.plantImage.sprite = plantData.plantImage;
        this.plantNeedSun.text = plantData.plantNeedSun.ToString();
        this.plantMaxCD = plantData.plantCD;
    }
  
   public void NameTrue()
    {
        plantNameImage.gameObject.SetActive(true);
    }
    public void NameFalse()
    {
        plantNameImage.gameObject.SetActive(false);
    }
}
