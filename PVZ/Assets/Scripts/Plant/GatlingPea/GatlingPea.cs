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
        FindZombie();
        plantData = GetComponent<PlantAttributeManagement>().plantData;
        states.Add(PlantState.Idle, new GatlingPeaIdleState(this));
        states.Add(PlantState.Shoot, new GatlingPeaAttackState(this));
        if (hit.collider != null && hit.collider.gameObject.tag == "Zombie")
        {
            TransitionState(PlantState.Shoot);
        }
        else
        {
            TransitionState(PlantState.Idle);
        }
        plantBulletPool = GetComponent<PlantBulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        FindZombie();
        currentState.OnUpdate();
       // hit = Physics2D.Raycast(firePoint.transform.position, Vector2.right, 100f, layerMask);
     
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
}
