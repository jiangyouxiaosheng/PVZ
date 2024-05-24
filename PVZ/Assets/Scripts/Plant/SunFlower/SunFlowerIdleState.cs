using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerIdleState : IState
{
    private SunFlower manager;
    float instantiateTime;
    public SunFlowerIdleState(SunFlower sunFlower)
    {
        this.manager = sunFlower;
        instantiateTime = manager.plantData.plantAttackSpeed;
    }
    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
       
    }

    public void OnUpdate()
    {
        instantiateTime -= Time.deltaTime;
        if(instantiateTime < 0)
        {
            // SunManager.Instance.PreparedObject(Camera.main.WorldToScreenPoint(new Vector3(manager.transform.position.x, manager.transform.position.y, manager.transform.position.z)));
            manager.Sun();
            instantiateTime = manager.plantData.plantAttackSpeed;
        }
    }
}
