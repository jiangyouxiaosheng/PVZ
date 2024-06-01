using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutMan : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData_SO plantData;
    public Animator _animator_Children;
    public PlantAttributeManagement attributeManagement;
    public CapsuleCollider2D _capsuleCollider2;
    [SerializeField]
    private Transform firePoint;
    public PlantBulletPool _plantBulletPool  => GetComponent<PlantBulletPool>();
    public RaycastHit2D hit;
    public LayerMask layerMask;
    public float waitAttackTime;
    // Start is called before the first frame update
    private void Awake()
    {
        // _animator_Children = GetComponentInChildren<Animator>();
        attributeManagement = GetComponent<PlantAttributeManagement>();
        _capsuleCollider2 = GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        states.Add(PlantState.Idle, new WallnutManIdleState(this));
        states.Add(PlantState.Shoot, new WallnutManAttackIdle(this));
        TransitionState(PlantState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        waitAttackTime -=Time.deltaTime;
        currentState.OnUpdate();
        FindZombie();
        if (hit.collider != null && hit.collider.gameObject.tag == "Zombie" && waitAttackTime<=0)
        {
            TransitionState(PlantState.Shoot);
        }
        else
        {
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
        hit = Physics2D.Raycast(firePoint.transform.position, Vector2.right, 1f, layerMask);
    }
    public void Attack()
    {
        _plantBulletPool.PreparedObject(firePoint);
        Debug.LogError("1111");
    }
}
