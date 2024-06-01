using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttributeManagement : MonoBehaviour
{
    public ZombieData_SO zombieData_SO;
    public ZombieData zombieData = new ZombieData();
    public NormalZombie normalZombie;
    public GameObject iceImage;
    public GameObject iceSpecialEffects;
    public GameObject wallnutEffects;
    private float wallnutTimer;
    public float cantMoveTime;
    public float moveSpeedDownTime;
    public bool isCantMove;
    
    private void Start()
    {
        normalZombie = GetComponent<NormalZombie>();
        Init();

    }


    private void Update()
    {
        wallnutTimer -=Time.deltaTime;
        ZombieMoveSpeedDown();
        if (isCantMove)
        {
            ZombieIsCantMove();
        }
        if (wallnutTimer < 0)
        {
            wallnutEffects.SetActive(false);
        }
  
       
    }
    public void Init()
    {
        zombieData.Init(zombieData_SO);
        normalZombie.TransitionState(ZombieState.Move);
    }
    public void ZombieIsInjury(int damage)
    {
        zombieData.zombieHp -= damage;
    }

    public void ZombieIsDie()
    {
        zombieData.zombieHp = 0;
    }


    public void ZombieIsCantMove()
    {
        cantMoveTime -= Time.deltaTime;
        if(cantMoveTime > 0)
        {
            
            zombieData.zombieMoveSpeed = 0;
            iceImage.SetActive(true);
            iceImage.SetActive(true);
        }
        else
        {
            
            zombieData.zombieMoveSpeed = zombieData_SO.zombieMoveSpeed;
            iceImage.SetActive(false);
            cantMoveTime = 0;
            iceImage.SetActive(false);
            isCantMove = false;
        }
      
    }

    public void ZombieMoveSpeedDown()
    {
        moveSpeedDownTime -= Time.deltaTime;
        if(moveSpeedDownTime > 0)
        {
            iceSpecialEffects.SetActive(true);
            zombieData.zombieMoveSpeed = zombieData_SO.zombieMoveSpeed/2;
        }
        else
        {
            moveSpeedDownTime = 0;
            iceSpecialEffects.SetActive(false);
            zombieData.zombieMoveSpeed = zombieData_SO.zombieMoveSpeed ;
        }
    }

    public void WallnutAttack()
    {
        wallnutTimer = 0.2f;
        wallnutEffects.gameObject.SetActive(true);
    }

}
