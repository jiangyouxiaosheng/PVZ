using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState,IState> states = new Dictionary<PlantState,IState>();
    public PlantData plantData;
    public Transform firePoint;
    public PlantBulletPool plantBulletPool;
    public RaycastHit2D hit;
    void Start()
    {
        plantData = GetComponent<PlantAttributeManagement>().plantData;
        states.Add(PlantState.Idle,new PeashooterIdleState(this));
        states.Add(PlantState.Shoot, new PeaShooterAttackState(this));
        TransitionState(PlantState.Idle);
        plantBulletPool = GetComponent<PlantBulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        hit = Physics2D.Raycast(transform.position, Vector2.right);
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
