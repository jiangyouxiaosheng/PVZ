using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeashooterGirlIdleState : IState
{
    private PeaShooterGirl manager;
    public PeashooterGirlIdleState(PeaShooterGirl manager)
    {
        this.manager = manager;
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

    }
}
