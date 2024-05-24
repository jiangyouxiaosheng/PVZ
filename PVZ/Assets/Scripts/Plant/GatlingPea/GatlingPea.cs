using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingPea : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData plantData;
    public Transform firePoint;
    public PlantBulletPool plantBulletPool;
    public RaycastHit2D hit;
    public Animator _animator;
    public LayerMask layerMask;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {

        plantData = GetComponent<PlantAttributeManagement>().plantData;
        states.Add(PlantState.Idle, new GatlingPeaIdleState(this));
        states.Add(PlantState.Shoot, new GatlingPeaAttackState(this));
        TransitionState(PlantState.Idle);
        plantBulletPool = GetComponent<PlantBulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        hit = Physics2D.Raycast(firePoint.transform.position, Vector2.right, 100f, layerMask);
        Debug.LogError(hit.collider);
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
