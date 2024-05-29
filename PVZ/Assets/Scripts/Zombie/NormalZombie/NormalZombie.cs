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
    public Transform eatPoint;
    public LayerMask layerMask;
    public Animator _animator;
    public ZombieAttributeManagement attributeManagement;
    public AudioSource _audioSource => GetComponent<AudioSource>();
    void Start()
    {
        attributeManagement = GetComponent<ZombieAttributeManagement>();
        states.Add(ZombieState.Move, new ZombieMoveState(this));
        states.Add(ZombieState.Eat, new ZombieEatState(this));
        states.Add(ZombieState.Die,new ZombieDiestate(this));
        states.Add(ZombieState.Run, new ZombieRunState(this));
        TransitionState(ZombieState.Move);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        hit = Physics2D.Raycast(eatPoint.transform.position, Vector2.left, 0.1f,layerMask); 
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
