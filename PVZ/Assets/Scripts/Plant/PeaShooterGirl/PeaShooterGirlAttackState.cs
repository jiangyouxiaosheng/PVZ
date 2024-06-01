using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterGirlAttackState : IState
{
    private PeaShooterGirl manager;
    public PeaShooterGirlAttackState(PeaShooterGirl manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        manager._animator.Play("gongji");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}
