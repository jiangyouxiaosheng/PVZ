using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Zombie/ZombieData")]
public class ZombieData_SO : ScriptableObject
{
    public string zombieName;
    public Sprite zombieImage;
    public int zombieHp;
    public float zombieAttackSpeed;
    public float zombieMoveSpeed;
    public GameObject zombiePrefabs;
    public int zombieAttack;


    public void Init()
    {
        zombieHp = 60;
        zombieMoveSpeed = 0.5f;
        zombieAttack = 10;
    }

}


