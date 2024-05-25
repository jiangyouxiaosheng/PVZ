using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData_SO plantData;
    public Animator _animator;
    public PlantAttributeManagement attributeManagement;

    private void Awake()
    {
        attributeManagement = GetComponent<PlantAttributeManagement>();
       // _animator = GetComponent<Animator>();
    }

    void Start()
    {
        states.Add(PlantState.Idle, new PumpkinIdleState(this));
        TransitionState(PlantState.Idle);

    }

    void Update()
    {
        currentState.OnUpdate();
    }
    public void TransitionState(PlantState type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
}
