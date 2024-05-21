using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI sunCountText;
    public Transform plantChoosed;
    public Transform UICanvas;
    public Transform plantCancelChoose;
    public Transform plantCanceParent;
    public Dictionary<int,GameObject> plantIDGameobject = new Dictionary<int,GameObject>();
    public List<GameObject> plantChoosedPlant = new List<GameObject>();
  public InventoryUI inventoryUI => GetComponent<InventoryUI>();


    private void Update()
    {
        sunCountText.text = SunManager.Instance.SunCount().ToString();
    
    }

    public void UIStartAnimation()
    {
        inventoryUI.UIStartAnimation();
    }


    public void ChoosedCardChange()
    {
      for(int i = 0; i < plantChoosedPlant.Count; i++)
        {
            
            plantChoosedPlant[i].GetComponent<PlantSlotChoose>().IsReadyDestroy();
        }
    }
}
