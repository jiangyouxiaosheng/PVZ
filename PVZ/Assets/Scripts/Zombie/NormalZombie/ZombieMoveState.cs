using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ZombieMoveState : IState
{
    private NormalZombie manager;
    //  private PlantData plantData;

    public ZombieMoveState(NormalZombie normalZombie)
    {
        this.manager = normalZombie;
      //  this.plantData = manager.plantData;
    }
    public void OnEnter()
    {
       
    }

    public void OnUpdate()
    {
        manager.transform.Translate(Vector2.left * Time.deltaTime * manager.zombieData.zombieMoveSpeed);
    
        if(manager.hit.collider != null)
        {
            manager.TransitionState(ZombieState.Eat);
        }

       
    }
    public void OnExit()
    {
      
    }

 
}
