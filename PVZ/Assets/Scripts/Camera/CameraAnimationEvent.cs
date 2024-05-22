using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationEvent : MonoBehaviour
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
       
    }
    private void OnEnable()
    {
        EventHandler.GameStartCameraMoveEvent += StartCameraAnimationPlay;
        EventHandler.ChooseEndCameraMoveEvent += ChooseEndCameraAnimationPlay;
    }

    public void StartCameraAnimationPlay()
    {
        _animator.Play("GameStartCameraAnim");
    }

   public void PlantChooseUISetActiveTrue()
   {
        UIManager.Instance.UIStartAnimation();
   }
    public void ChooseEndCameraAnimationPlay()
    {
        _animator.Play("ChooseEndCameraAnim");
    }
    public void InstantiateCarAndReadyTextAnimation()
    {
        CarManager.Instance.InstantiateCar();
        UIManager.Instance.UIReadySetPlantAnimation();

    }
}
