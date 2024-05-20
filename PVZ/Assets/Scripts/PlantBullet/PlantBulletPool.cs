using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefabs;//子弹模型

    Queue<GameObject> groundQueue = new Queue<GameObject>();
    private Transform thisTransform;
    int size = 10;




    #region 生成对象池
    //复制预制体对象 加入对象池
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(bulletPrefabs, transform);
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
        proparedObject.transform.position = pos.position;
        return proparedObject;
    }



    //让已用过的对象返回对象池(可与启用写在同一函数中)
    public void Return(GameObject gameObject)
    {
        gameObject.SetActive(false);
        groundQueue.Enqueue(gameObject);

    }

    #endregion


}
