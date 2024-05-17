using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState,IState> states = new Dictionary<PlantState,IState>();
    public PlantData plantData = new PlantData() {plantHp =1};
    public PlantData_SO plantDatalsit;
    void Start()
    {
        states.Add(PlantState.Idle,new PeashooterIdleState(this));
        states.Add(PlantState.Shoot, new PeaShooterAttackState(this));
        TransitionState(PlantState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(PlantState type)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
}
