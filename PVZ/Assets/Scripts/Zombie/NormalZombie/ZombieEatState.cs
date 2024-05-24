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
        Debug.LogError(manager.zombieData.zombieName + "进入了吃植物的状态");
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
                    manager.hit.collider.GetComponent<PlantAttributeManagement>().PlantIsInjury(10);
                    timer = 1;
                }

            }
        }
        else
        {
            
                manager.TransitionState(ZombieState.Move);
            
        }
       

    }
    public void OnExit()
    {

    }
}
