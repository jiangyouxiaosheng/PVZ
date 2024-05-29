using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ZombieManager : Singleton<ZombieManager>
{
    public List<GameObject> zombieList = new List<GameObject>();
    public GameObject zombieObj;
    public ZombieData_SO ZombieData_SO;
    Queue<GameObject> groundQueue = new Queue<GameObject>();
    int size = 100;
    Transform thisTransform;
    public Transform[] pos;
    public float normalZombieTime;//正常的出僵尸的速度
    public float maxNormalTime;//尸潮来袭
    public float zombieStartTime;//游戏开始等待时间
    public bool zombieStart;
    public bool isZombiesComing;//是否来袭尸潮
    public float zombiesLastTime;//尸潮持续时间
    public float zombiesCurrentLastTime;
    public float zombieComeTime;//尸潮间隔


    private void Start()
    {
       
        zombiesLastTime = 10f;
        maxNormalTime = normalZombieTime;
        Init(transform);
        zombiesCurrentLastTime = 10f;
    }


    private void Update()
    {

     
        if (isZombiesComing)
        {
            normalZombieTime = 0.3f;//尸潮出僵尸的速度
            zombiesLastTime -= Time.deltaTime;
            if (zombiesLastTime < 0)
            {
                isZombiesComing = false;
                zombiesLastTime = zombiesCurrentLastTime;
            }
        }
        else
        {
            normalZombieTime = maxNormalTime;
        }
        InstantiateZombie();
    }

 
    public void InstantiateZombie()
    {
        zombieStartTime-=Time.deltaTime;
        if (zombieStartTime < 0 && zombieStart)
        {
            zombieStartTime = normalZombieTime;
            int r = Random.Range(0, 5);
            PreparedObject(pos[r]);
        }
    }



    public void AllZombieStop()
    {
        for(int i = 0; i < zombieList.Count; i++)
        {
            ZombieAttributeManagement zombieAttributeManagement = zombieList[i].GetComponent<ZombieAttributeManagement>();
            zombieAttributeManagement.cantMoveTime =  2f;
            zombieAttributeManagement.isCantMove = true;
           zombieAttributeManagement.moveSpeedDownTime = 8f;
        }
    }


    public void AllZombieDamage()
    {
        for (int i = 0; i < zombieList.Count; i++)
        {
            ZombieAttributeManagement zombieAttributeManagement = zombieList[i].GetComponent<ZombieAttributeManagement>();
            zombieAttributeManagement.ZombieIsInjury(500);
  
        }
    }



    #region 生成对象池
    //复制预制体对象 加入对象池
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(zombieObj, transform);
        copy.SetActive(false);
        return copy;
    }
    //初始化对象池 将所有对象入队
    public void Init(Transform parent)
    {
        groundQueue = new Queue<GameObject>();
        this.thisTransform = parent;
        for (int i = 0; i < size; i++)
        {
            groundQueue.Enqueue(Copy());
        }
    }

    //从池中取出可用的对象
    GameObject AvailableObject()
    {
        GameObject avaliableObject = null;
        if (groundQueue.Count > 0)
        {
            avaliableObject = groundQueue.Dequeue();
        }
        else
        {
            avaliableObject = Copy();
        }

        //queue.Enqueue(avaliableObject);
        return avaliableObject;
    }

    //启用可用的对象
    public GameObject PreparedObject(Transform pos)
    {
        GameObject proparedObject = AvailableObject();
        proparedObject.SetActive(true);
        zombieList.Add(proparedObject);
        proparedObject.transform.position = pos.position;
        return proparedObject;
    }



    //让已用过的对象返回对象池(可与启用写在同一函数中)
    public void Return(GameObject gameObject)
    {
        gameObject.SetActive(false);
        groundQueue.Enqueue(gameObject);
        zombieList.Remove(gameObject);
    }

    #endregion

}
