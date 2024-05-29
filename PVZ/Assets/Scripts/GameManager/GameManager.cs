using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int isCanUsePlantNum;
    public float gameTime;
    public bool gameStart;
 
    public PlantDataList_SO plantDataList_SO;
    public ZombieData_SO zombieData_SO;
   // public List<GameObject> plantList = new List<GameObject>();
    private void Awake()
    {
       plantDataList_SO.Init();
       zombieData_SO.Init();
    }

    private void OnEnable()
    {
        EventHandler.GameStartEvent += GameStart;
      
    }
    private void OnDisable()
    {
        EventHandler.GameStartEvent -= GameStart;
    }
    private void Start()
    {
        EventHandler.GameStartCameraMove();
    }
    private void Update()
    {
        if (gameStart)
        {
            gameTime += Time.deltaTime;
            if((int)gameTime % ZombieManager.Instance.zombieComeTime == 0 && (int)gameTime >1f)
            {
                ZombieManager.Instance.isZombiesComing = true;
              
                EventHandler.ZombieIsComming(); 
            
            }
        }

   
    }
    public void GameStart()
    {
        gameStart = true;
        SunManager.Instance.dayIsDay = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            EventHandler.GameOver();
        }
    }


}
