using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PeaShooterAttackState : IState
{
    private Peashooter manager;
    float timer;

    public PeaShooterAttackState(Peashooter peashooter)
    {
        this.manager = peashooter;
   
    }
    public void OnEnter()
    {
        timer = manager.plantData.plantAttackSpeed;
    }
    public void OnUpdate()
    {
      
       timer -=Time.deltaTime;
        if(timer <= 0)
        {
            manager.plantBulletPool.PreparedObject(manager.firePoint);
            timer = manager.plantData.plantAttackSpeed;
        }
       
    }


    public void OnExit()
    {

    }
}
