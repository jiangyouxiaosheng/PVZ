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
    public Animator _animator;
    public LayerMask layerMask;
    public GameObject gatlingCanUse;
    public PlantAttributeManagement attributeManagement;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        attributeManagement = GetComponent<PlantAttributeManagement>();
        plantData = GetComponent<PlantAttributeManagement>().plantData;
        states.Add(PlantState.Idle,new PeashooterIdleState(this));
        states.Add(PlantState.Shoot, new PeaShooterAttackState(this));
        TransitionState(PlantState.Idle);
        plantBulletPool = GetComponent<PlantBulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gatlingCanUse!=null)
        {
            if (MapCreate.Instance.isCanSet)
            {
                gatlingCanUse.SetActive(true);
            }
            else
            {
                gatlingCanUse.SetActive(false);
            }
        }
   
        currentState.OnUpdate();
        hit = Physics2D.Raycast(firePoint.transform.position, Vector2.right,100f,layerMask);
    
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
