using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingPeaIdleState : IState
{
    private GatlingPea manager;
    private float idleTimer;

    public GatlingPeaIdleState(GatlingPea peashooter)
    {
        this.manager = peashooter;

    }
    public void OnEnter()
    {
        idleTimer = manager.plantData.plantAttackSpeed;
        manager._animator.Play("daiji");
    }
    public void OnUpdate()
    {

        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            if (manager.hit.collider != null)
            {
                if (manager.hit.collider.gameObject.tag == "Zombie")
                {
                    manager.TransitionState(PlantState.Shoot);
                }
            }
        }


    }


    public void OnExit()
    {

    }
}
