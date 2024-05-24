using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighWalnutIdleState : IState
{
    private HighWalnut manager;
    private int highWalnutHp;
    public HighWalnutIdleState(HighWalnut highWalnut)
    {
        this.manager = highWalnut;
        
    }

    public void OnEnter()
    {
        
          manager._animator_Children.Play("daiji");
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {

        //if (manager.attributeManagement.plantData.plantHp <= 50)
        //{
        //    manager._animator.Play("daiji2");
        //}

       
        if (manager.attributeManagement.plantData.plantHp <60 && manager.attributeManagement.plantData.plantHp > 30)
        {
            manager._animator_Children.Play("daiji2");
        }
        if (manager.attributeManagement.plantData.plantHp < 30)
        {
            manager._animator_Children.Play("daiji3");
        }
        if (manager.attributeManagement.plantData.plantHp <= 0)
        {
            manager._animator.Play("HighWalnut");
        }
    }


}
