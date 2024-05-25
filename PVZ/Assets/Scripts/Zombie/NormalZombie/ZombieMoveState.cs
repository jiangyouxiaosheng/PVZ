using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ZombieMoveState : IState
{
    private NormalZombie manager;
    float timer;
    //  private PlantData plantData;

    public ZombieMoveState(NormalZombie normalZombie)
    {
        this.manager = normalZombie;
        
    }
    public void OnEnter()
    {

        timer = 2f;
    }

    public void OnUpdate()
    {
        timer -= Time.deltaTime;
        manager.transform.Translate(Vector2.left * Time.deltaTime * manager.attributeManagement.zombieData.zombieMoveSpeed);
        MoveState(manager.attributeManagement.zombieData.zombieHp);
        if(timer <= 0)
        {
            manager.TransitionState(ZombieState.Run);

        }
        if (manager.attributeManagement.zombieData.zombieHp <= 0)
        {
            manager.TransitionState(ZombieState.Die);
        }
        if (manager.hit.collider != null && manager.hit.collider.GetComponent<PlantAttributeManagement>()!=null)
        {
            manager.TransitionState(ZombieState.Eat);
        }

       
    }
    public void OnExit()
    {
        timer = 2f;
    }

    void MoveState(int hp)
    {
        if (hp <= 0)
        {
           // manager.TransitionState(null);
        }
        switch(hp)
        {
            case > 50:
                manager._animator.Play("ÒÆ¶¯");
                break;
            case  <=50:
                manager._animator.Play("¶ÏÊÖ×ß");
                break;
        }
    }
 
}
