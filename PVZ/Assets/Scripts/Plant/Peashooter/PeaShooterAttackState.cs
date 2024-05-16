using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterAttackState : IState
{
    private Peashooter manager;
    private PlantData plantData;

    public PeaShooterAttackState(Peashooter peashooter)
    {
        this.manager = peashooter;
        this.plantData = manager.plantData;
    }
    public void OnEnter()
    {

    }
    public void OnUpdate()
    {
       
    }


    public void OnExit()
    {

    }
}
