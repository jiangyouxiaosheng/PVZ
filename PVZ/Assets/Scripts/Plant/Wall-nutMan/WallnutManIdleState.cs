using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutManIdleState : IState
{
    private WallnutMan manager;
    public  WallnutManIdleState(WallnutMan manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        manager._animator_Children.Play("daiji");
    }

    public void OnUpdate()
    {

    }
    public void OnExit()
    {
        
    }

 
}
