using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI :MonoBehaviour
{
    public GameObject drawImage;
    private Animator _animator;
    public GameObject plantChooseBackground;
    public Transform choosedPlantSlot;
    public List<GameObject> plantChooseBackgroundList;
    public PlantChooseUI plantSlotChoose => GetComponentInChildren<PlantChooseUI>();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
      //  Debug.LogError(GameManager.Instance.isCanUsePlantNum);
        //for (int i = 0; i < 8; i++)
        //{
        //    var obj = Instantiate(plantChooseBackground, choosedPlantSlot);
        //    plantChooseBackgroundList.Add(obj);
        //}
    }
    private void Update()
    {
        
    }


    public void UIStartAnimation()
    {
        _animator.Play("GameStartPlantChooseUI");
    }
    public void UIEndAnimation()
    {
        _animator.Play("GameEndPlantChooseUI");
    }

    public void UIReadySetPlantAnimation()
    {
        _animator.Play("ReadyTextAnim");
    }

    public void InstantiateCarAndReadyTextAnimation()
    {
       // UIManager.Instance.UIReadySetPlantAnimation();
        UIReadySetPlantAnimation();
        CarManager.Instance.InstantiateCar();
    }
    public void StartButtonSetactive()
    {

        if (UIManager.Instance.startPlant.Count > 0)
        {
            plantSlotChoose.isCanStart.gameObject.SetActive(true);
        }
        else
        {
            plantSlotChoose.isCanStart.gameObject.SetActive(false);
        }
    }
    public Transform ChoosedSlotIsNull()
    {
        for(int i = 0; i < plantChooseBackgroundList.Count; i++)
        {
            if (plantChooseBackgroundList[i].GetComponent<PlantSlotBackGround>().isUsed == false)
            {
                return plantChooseBackgroundList[i].GetComponent<PlantSlotBackGround>().transform;
            }
          
        }
        return null;
    }
}
