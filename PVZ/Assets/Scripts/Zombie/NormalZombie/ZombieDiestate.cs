using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieDiestate : IState
{
    private NormalZombie manager;
    float timer;
    public ZombieDiestate(NormalZombie normalZombie)
    {
     
        this.manager = normalZombie;

    }
    public void OnEnter()
    {
        timer = 1f;
       
        manager._animator.Play("À¿Õˆ");
    }
    public void OnUpdate()
    {
        timer -=Time.deltaTime;
        if(timer < 0)
        {
            ZombieManager.Instance.Return(manager.gameObject);
            manager.attributeManagement.Init();
        }
    }

    public void OnExit()
    {
       
    }

 
}
