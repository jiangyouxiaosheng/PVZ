using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameEventManager : MonoBehaviour
{
    public GameObject eventPanl;
    public Image eventIamge;
    public Text eventTextTile;
    public Text eventText;

    public List<Image> imageList = new List<Image>();
    public float eventChangeTime;
    private float currenteventChangeTime;
    private int eventNum;

    private void Awake()
    {
       currenteventChangeTime = eventChangeTime;
    }



    private void Update()
    {
        currenteventChangeTime -=Time.deltaTime;
        if (currenteventChangeTime <= 0)
        {   
         
            int i = 1;
            switch (i)
            {
                case 1:
                    ZombieAttackIsDown();
                    break;

            }
            currenteventChangeTime = eventChangeTime;
        }


    }

    void ZombieAttackIsDown()
    {
        if (ZombieManager.Instance.ZombieData_SO.zombieAttack > 1)
        {
            ZombieManager.Instance.ZombieData_SO.zombieAttack -= 1;
            eventTextTile.text=
        } 
    }
    
   
   


}
