using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighWalnut : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData_SO plantData;
    public Animator _animator_Children;
    public Animator _animator;
    public PlantAttributeManagement attributeManagement;
    public CapsuleCollider2D _capsuleCollider2;
    // Start is called before the first frame update
    private void Awake()
    {
       // _animator_Children = GetComponentInChildren<Animator>();
         attributeManagement = GetComponent<PlantAttributeManagement>();
         _capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        states.Add(PlantState.Idle, new HighWalnutIdleState(this));
        TransitionState(PlantState.Idle);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        if(attributeManagement.plantData.plantHp <= 0)
        {
            _capsuleCollider2.isTrigger = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieAttributeManagement>().ZombieIsDie();
        }
    }
}
