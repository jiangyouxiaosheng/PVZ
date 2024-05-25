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
    public float normalZombieTime;//�����ĳ���ʬ���ٶ�
    public float maxNormalTime;//ʬ����Ϯ
    public float zombieStartTime;//��Ϸ��ʼ�ȴ�ʱ��
    public bool isZombiesComing;//�Ƿ���Ϯʬ��
    public float zombiesLastTime;//ʬ������ʱ��



    private void Start()
    {
        maxNormalTime = normalZombieTime;
        Init(transform);
     
    }


    private void Update()
    {
        InstantiateZombie();
        if (isZombiesComing)
        {
           
            normalZombieTime = 0.1f;
         
        }
        else
        {
            normalZombieTime = maxNormalTime;
        }
    }

 
    public void InstantiateZombie()
    {
        
        zombieStartTime-=Time.deltaTime;
        if (zombieStartTime < 0)
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



    #region ���ɶ����
    //����Ԥ������� ��������
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(zombieObj, transform);
        copy.SetActive(false);
        return copy;
    }
    //��ʼ������� �����ж������
    public void Init(Transform parent)
    {
        groundQueue = new Queue<GameObject>();
        this.thisTransform = parent;
        for (int i = 0; i < size; i++)
        {
            groundQueue.Enqueue(Copy());
        }
    }

    //�ӳ���ȡ�����õĶ���
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

    //���ÿ��õĶ���
    public GameObject PreparedObject(Transform pos)
    {
        GameObject proparedObject = AvailableObject();
        proparedObject.SetActive(true);
        zombieList.Add(proparedObject);
        proparedObject.transform.position = pos.position;
        return proparedObject;
    }



    //�����ù��Ķ��󷵻ض����(��������д��ͬһ������)
    public void Return(GameObject gameObject)
    {
        gameObject.SetActive(false);
        groundQueue.Enqueue(gameObject);
        zombieList.Remove(gameObject);
    }

    #endregion

}
