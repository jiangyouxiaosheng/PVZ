using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingPeaAttackState : IState
{
    private GatlingPea manager;
    float timer;
    float attackWaitTime = 0.5f;
    int attackNum;
    public GatlingPeaAttackState(GatlingPea peashooter)
    {
        this.manager = peashooter;

    }
    public void OnEnter()
    {
        attackNum = 0;
        timer = 0;
        manager._animator.Play("gongji");
    }
    public void OnUpdate()
    {


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            attackNum++;
            manager.plantBulletPool.PreparedObject(manager.firePoint);
            timer = attackWaitTime;
            if (attackNum >= manager.plantData.plantAttackNum)
            {
                manager.TransitionState(PlantState.Idle);
            }


        }



    }


    public void OnExit()
    {

    }
}
