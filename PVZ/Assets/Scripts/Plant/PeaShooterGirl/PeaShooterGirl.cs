using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterGirl : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData plantData;
    public Transform firePoint;
    public PlantBulletPool plantBulletPool;
    public RaycastHit2D hit;
    public Animator _animator;
    public LayerMask layerMask;
    public PlantAttributeManagement attributeManagement;
    public int shootNum;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindZombie();
        attributeManagement = GetComponent<PlantAttributeManagement>();
        plantData = GetComponent<PlantAttributeManagement>().plantData;
        states.Add(PlantState.Idle, new PeashooterGirlIdleState(this));
        states.Add(PlantState.Shoot, new PeaShooterGirlAttackState(this));
        TransitionState(PlantState.Idle);
        plantBulletPool = GetComponent<PlantBulletPool>();
    }
    void Update()
    {
        currentState.OnUpdate();
        FindZombie();
        if (hit.collider != null && hit.collider.gameObject.tag == "Zombie")
        {
            TransitionState(PlantState.Shoot);
        }
        else
        {
            Debug.LogError("´ý»ú");
            TransitionState(PlantState.Idle);
        }

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
    void FindZombie()
    {
        hit = Physics2D.Raycast(firePoint.transform.position, Vector2.right, 100f, layerMask);
    }
    public void Shoot()
    {
        plantBulletPool.PreparedObject(firePoint);
        shootNum++;
    }

}
