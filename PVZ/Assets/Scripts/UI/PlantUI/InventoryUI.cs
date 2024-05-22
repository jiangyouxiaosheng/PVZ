using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI :MonoBehaviour
{
    public GameObject drawImage;
    private Animator _animator;
    public PlantChooseUI plantSlotChoose => GetComponentInChildren<PlantChooseUI>();
    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
        _animator.Play("ReadyText");
    }
    public void StartButtonSetactive()
    {

        if (UIManager.Instance.plantChoosedPlant.Count > 0)
        {
            plantSlotChoose.isCanStart.gameObject.SetActive(true);
        }
        else
        {
            plantSlotChoose.isCanStart.gameObject.SetActive(false);
        }
    }
}
