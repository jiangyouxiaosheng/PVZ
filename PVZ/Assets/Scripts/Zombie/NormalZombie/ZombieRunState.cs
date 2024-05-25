using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRunState : IState
{
    private NormalZombie manager;
    float timer =1;
    public ZombieRunState(NormalZombie normalZombie)
    {
        this.manager = normalZombie;

    }
    public void OnEnter()
    {
       
    }
    public void OnUpdate()
    {
        RunState(manager.attributeManagement.zombieData.zombieHp);
        manager.transform.Translate(Vector2.left * Time.deltaTime * manager.attributeManagement.zombieData.zombieMoveSpeed*2);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            manager.TransitionState(ZombieState.Move);
            timer = 1;
        }
        if (manager.hit.collider != null && manager.hit.collider.GetComponent<PlantAttributeManagement>() != null)
        {
            manager.TransitionState(ZombieState.Eat);
        }
        if (manager.attributeManagement.zombieData.zombieHp <= 0)
        {
            manager.TransitionState(ZombieState.Die);
        }
    }

    public void OnExit()
    {

    }

    void RunState(int hp)
    {
        if (hp <= 0)
        {
            // manager.TransitionState(null);
        }
        switch (hp)
        {
            case > 50:
                manager._animator.Play("³å´Ì");
                break;
            case <= 50:
                manager._animator.Play("¶ÏÊÖ³å´Ì");
                break;
        }
    }
}
