using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinIdleState : IState
{
    private Pumpkin manager;
    private int pumpkinHp;
    public PumpkinIdleState(Pumpkin pumpkin)
    {
        this.manager = pumpkin;

    }

    public void OnEnter()
    {
        manager._animator.Play("daiji");

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if(manager.attributeManagement.plantData.plantHp<=60 && manager.attributeManagement.plantData.plantHp > 30)
        {
            manager._animator.Play("daiji2");
        }

        if (manager.attributeManagement.plantData.plantHp <= 30 && manager.attributeManagement.plantData.plantHp > 0)
        {
            manager._animator.Play("daiji3");
        }
      
    }
}
