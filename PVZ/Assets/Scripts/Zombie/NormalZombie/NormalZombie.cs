using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    private IState currentState;
    private Dictionary<ZombieState, IState> states = new Dictionary<ZombieState, IState>();
    public ZombieData_SO zombieData;
    public RaycastHit2D hit;

    void Start()
    {
        states.Add(ZombieState.Move, new ZombieMoveState(this));
        states.Add(ZombieState.Eat, new ZombieEatState(this));
        TransitionState(ZombieState.Move);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        hit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f); 
    }

    public void TransitionState(ZombieState type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
}
