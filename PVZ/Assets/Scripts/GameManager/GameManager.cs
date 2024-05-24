using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int isCanUsePlantNum;
    private void Awake()
    {
       
    }

    private void Start()
    {
        EventHandler.GameStartCameraMove();
    }
    private void Update()
    {
   
    }

  
}
