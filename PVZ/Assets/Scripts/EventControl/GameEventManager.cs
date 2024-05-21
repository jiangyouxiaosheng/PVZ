using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEventManager : MonoBehaviour
{
    
    public float eventChangeTime;
    private float eventChangeTimeRecord;
    

    private void Awake()
    {
        eventChangeTimeRecord = eventChangeTime;
    }



    private void Update()
    {
        
    }
    


}
