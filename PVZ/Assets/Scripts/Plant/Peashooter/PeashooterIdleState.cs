using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeashooterIdleState : IState
{
    private Peashooter manager;
    private PlantData plantData;


    private float idleTimer;

    public PeashooterIdleState(Peashooter peashooter)
    {
        this.manager = peashooter;
        this.plantData = manager.plantData;  
    }
    public void OnEnter()
    {
        idleTimer = 2f;
    }
    public void OnUpdate()
    {
        idleTimer -= Time.deltaTime;
        Debug.LogError(plantData.plantHp);
        Debug.LogError("´ý»ú×´Ì¬");
        if (idleTimer < 0 )
        {
            manager.TransitionState(PlantState.Shoot);
            
        }
     
    }


    public void OnExit()
    {
        
    }

   
}
