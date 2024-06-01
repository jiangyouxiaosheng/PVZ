using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutManAttackIdle : IState
{
    private WallnutMan manager;
    public WallnutManAttackIdle(WallnutMan manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        manager._animator_Children.Play("gongji");
    }

    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }

}
