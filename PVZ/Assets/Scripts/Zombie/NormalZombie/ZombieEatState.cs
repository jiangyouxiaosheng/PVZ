using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ZombieEatState : IState
{
    private float timer =1;
    private NormalZombie manager;
  

    public ZombieEatState(NormalZombie normalZombie)
    {
        this.manager = normalZombie;
    }
    public void OnEnter()
    {
        manager._audioSource.Play();
        //Debug.LogError(manager.zombieData.zombieName + "进入了吃植物的状态");

    }

    public void OnUpdate()
    {
        timer -=Time.deltaTime;
        if(manager.hit.collider != null)
        {
            if (manager.hit.collider.gameObject.tag == "Plant")
            {
                if (timer < 0)
                {
                    
                    manager.hit.collider.GetComponent<PlantAttributeManagement>().PlantIsInjury(manager.zombieData.zombieAttack);
                    timer = 1;
                }

            }
        }
        else
        {
                manager.TransitionState(ZombieState.Move);
        }
        EatState(manager.attributeManagement.zombieData.zombieHp);
        if (manager.attributeManagement.zombieData.zombieHp <= 0)
        {
            manager.TransitionState(ZombieState.Die);
        }
    }
    public void OnExit()
    {
        manager._audioSource.Stop();
    }
    void EatState(int hp)
    {
        if (hp <= 0)
        {
            // manager.TransitionState(null);
        }
        switch (hp)
        {
            case > 50:
                manager._animator.Play("攻击");
                break;
            case <= 50:
                manager._animator.Play("断手攻击");
                break;
        }
    }
}
