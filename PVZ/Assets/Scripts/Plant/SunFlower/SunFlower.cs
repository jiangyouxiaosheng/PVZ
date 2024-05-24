using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunFlower : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlantState, IState> states = new Dictionary<PlantState, IState>();
    public PlantData_SO plantData;
    public Transform firePoint;
    public GameObject sun;
 
    // Start is called before the first frame update
    void Start()
    {
        states.Add(PlantState.Idle, new SunFlowerIdleState(this));
        TransitionState(PlantState.Idle);
    }

    // Update is called once per frame
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

    public void Sun()
    {
        var sunobj = Instantiate(sun,UIManager.Instance.gameObject.transform);
        
        sunobj.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
}
