using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlotChoose : MonoBehaviour
{
    bool isChoosed;
    bool isCancelChoose;
    bool isChange;
    [SerializeField]
    private Image plantImage;
    [SerializeField]
    private TextMeshProUGUI plantNeedSun;
    [SerializeField]
    private Image plantCDImage;
    private float plantMaxCD;
    private float plantCurrentCD;
    public GameObject plantSlot;

    public PlantDataList_SO plantDatalist;
    public PlantData_SO plantData;
    public InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();


    private void Awake()
    {
        
    }
    private void Update()
    {
        if (isChoosed)
        {

            if (Vector3.Distance(transform.position, UIManager.Instance.plantChoosed.position) <= 0.3)
            {
                transform.SetParent(UIManager.Instance.plantChoosed);
                //UIManager.Instance.plantIDGameobject.Add(plantData.plantID,gameObject);
                UIManager.Instance.plantChoosedPlant.Add(gameObject);
                UIManager.Instance.inventoryUI.StartButtonSetactive();
                isChoosed = false;
                isChange = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, UIManager.Instance.plantChoosed.transform.position, 150 * Time.deltaTime);
            }
        }
        if (isCancelChoose)
        {
            if (Vector3.Distance(transform.position, UIManager.Instance.plantCancelChoose.position) <= 0.3)
            {
                transform.SetParent(UIManager.Instance.plantCanceParent);
                UIManager.Instance.plantChoosedPlant.Remove(gameObject);
                UIManager.Instance.inventoryUI.StartButtonSetactive();
                isCancelChoose = false;
                isChange = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,UIManager.Instance.plantCancelChoose.position, 150 * Time.deltaTime);
            }
        }
    }

    public void CardChoose()
    {
        if (isChange == false)
        {
            isChoosed = true;
         
            transform.SetParent(UIManager.Instance.UICanvas);

        }
        else
        {
         
            transform.SetParent(UIManager.Instance.UICanvas);
            isCancelChoose = true;
        }
      
    }
    public void SetSlotInformation(int ID)
    {
        plantData = plantDatalist.GetInventoryItem(ID);
        this.plantImage.sprite = plantData.plantImage;
        this.plantNeedSun.text = plantData.plantNeedSun.ToString();
        this.plantMaxCD = plantData.plantCD;
    }

    //点击开始按钮后
    public void IsReadyDestroy()
    {
        var obj=  Instantiate(plantSlot,transform.position,Quaternion.identity);
        obj.GetComponent<PlantSlot>().SetSlotInformation(plantData.plantID);
        obj.transform.SetParent(UIManager.Instance.plantChoosed);
        Destroy(gameObject);
    }



}
