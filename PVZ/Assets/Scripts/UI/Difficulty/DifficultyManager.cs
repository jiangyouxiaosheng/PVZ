using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public int isCanChooseNum;
    public GameObject difficultyChoose;
    public GameObject difficultyChooseManager;
    public int startSun;
    public float startTime;
    public int startZombieHp;
    public int startZombieAttack;
    public float startZombieMove;
    public int startPlantAttack;
    public float startPlantCD;
 
    private void OnEnable()
    {
        EventHandler.DiffficultyChooseEndEvent += DfficultyEnd;
    }
    private void OnDisable()
    {
        EventHandler.DiffficultyChooseEndEvent -= DfficultyEnd;
    }
    private void Start()
    {
        for(int i = 1; i <= isCanChooseNum; i++)
        {
            startSun = Random.Range(50, 200);
            startTime = Random.Range(10, 60);
            startZombieHp = Random.Range(-10, 10);
            startZombieAttack = Random.Range(-5, 5);
            startZombieMove = Random.Range(-0.2f, 0.2f);
            startPlantAttack = Random.Range(-3, 3);
            startPlantCD = Random.Range(-4, 4);

            var obj =  Instantiate(difficultyChoose,transform);
            obj.GetComponent<Difficulty>().Infomation(startSun,startTime,startZombieHp,startZombieAttack,startZombieMove,startPlantAttack,startPlantCD);
           
        }
  
    }

    
    private void DfficultyEnd()
    {
        difficultyChooseManager.gameObject.SetActive(false);
    }
}
