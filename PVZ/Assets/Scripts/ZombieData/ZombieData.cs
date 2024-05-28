using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieData 
{
    public string zombieName;
    public Sprite zombieImage;
    public int zombieHp;
    public float zombieAttackSpeed;
    public float zombieMoveSpeed;
    public GameObject zombiePrefabs;


    public void Init(ZombieData_SO zombieData_SO)
    {
        zombieName = zombieData_SO.zombieName;
        zombieImage = zombieData_SO.zombieImage;
        zombieHp =  zombieData_SO.zombieHp;
        zombieAttackSpeed = zombieData_SO.zombieAttackSpeed;
        zombieMoveSpeed = zombieData_SO.zombieMoveSpeed;
        zombiePrefabs = zombieData_SO.zombiePrefabs;

    }
}
