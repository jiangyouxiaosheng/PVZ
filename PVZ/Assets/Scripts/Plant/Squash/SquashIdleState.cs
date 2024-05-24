using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashIdleState : IState
{
    private Squash manager;

    public SquashIdleState(Squash squash)
    {
        this.manager = squash;
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
       if(manager.isLeft||manager.isRight)
       {
            if(manager.isLeft)
            {
                manager._animator_Children.Play("gongji");
                manager._animator.Play("SquashMoveLeft");
            }
            if (manager.isRight)
            {
                manager._animator_Children.Play("gongji");
                manager._animator.Play("SquashMoveRight");
            }
       }
    }

   
}
