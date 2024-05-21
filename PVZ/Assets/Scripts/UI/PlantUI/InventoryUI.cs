using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI :MonoBehaviour
{
    public GameObject drawImage;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void UIStartAnimation()
    {
        _animator.Play("GameStartPlantChooseUI");
    }
}
