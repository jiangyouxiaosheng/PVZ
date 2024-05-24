using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttributeManagement : MonoBehaviour
{
    [SerializeField]
    public ZombieData_SO zombieData_SO;
    public ZombieData zombieData = new ZombieData();



    private void Start()
    {
        zombieData.Init(zombieData_SO);
    }
    public void ZombieIsInjury(int damage)
    {
       
        zombieData.zombieHp -= damage;
  
        if (zombieData.zombieHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ZombieIsDie()
    {
        zombieData.zombieHp = 0;
        Destroy(gameObject);
    }

}
