using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squash : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData_SO plantData;
    public Animator _animator_Children;
    public Animator _animator;
    public PlantAttributeManagement attributeManagement;
    private BoxCollider2D _box =>GetComponent<BoxCollider2D>();
    public bool isRight,isLeft;
    private void Awake()
    {
       
        attributeManagement = GetComponent<PlantAttributeManagement>();
        _animator = GetComponent<Animator>();
    }


    void Start()
    {
        _box.enabled = true;
        states.Add(PlantState.Idle, new SquashIdleState(this));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            
                if (collision.gameObject.transform.position.x < transform.position.x)
                {
                    isLeft = true;
                    _box.enabled = false;
                }
                else
                {

                    isRight = true;
                    _box.enabled = false;
                }

            

        }
    }

    public void DestroyGameobject()
    {
        Destroy(gameObject);
    }

    public void VoicePlay()
    {
        VoiceManager.Instance.Squash();
    }
}
