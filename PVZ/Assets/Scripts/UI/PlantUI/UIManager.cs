using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI sunCountText;
    public Transform plantChoosed;
    public Transform UICanvas;
    public Transform plantCancelChoose;
    public Transform plantCanceParent;
    public Transform plantShovel;
    public Image shocelPanel;
    public Transform sunPoint;

    public List<GameObject> plantChoosedPlant = new List<GameObject>();
  public InventoryUI inventoryUI => GetComponent<InventoryUI>();

    private void Start()
    {
        shocelPanel.gameObject.SetActive(true); 
    }

    private void Update()
    {
        sunCountText.text = SunManager.Instance.SunCount().ToString();
    
    }

    public void UIStartAnimation()
    {
        inventoryUI.UIStartAnimation();
        
    }

    public void UIEndAnimation()
    {
        inventoryUI.UIEndAnimation();
    }
    public void UIReadySetPlantAnimation()
    {
        inventoryUI.UIReadySetPlantAnimation();
    }

    public void ChoosedCardChange()
    {
        shocelPanel.gameObject.SetActive(false);
        UIEndAnimation();
        for (int i = 0; i < plantChoosedPlant.Count; i++)
        {
            plantChoosedPlant[i].GetComponent<PlantSlotChoose>().IsReadyDestroy();
        }
        inventoryUI.plantSlotChoose.isCanStart.gameObject.SetActive(false);
        plantChoosedPlant.Clear();

    }
    public void ChooseEndCameraAnimationBack()
    {
        EventHandler.ChooseEndCameraMove();
    }
}
