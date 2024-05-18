using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SunManager : Singleton<SunManager>
{
    [SerializeField]
    private int currentSun;


    [SerializeField]
    private GameObject sunPrefabs;//阳光模型
    [SerializeField]
    private float createSunTime;// 需要时间
    float createSunLastTime;//距离下一次阳光生成的时间
    Queue<GameObject> groundQueue = new Queue<GameObject>();
    private Transform thisTransform;
    int size=2;


    private void Start()
    {
        createSunLastTime = createSunTime;
    }


    private void Update()
    {
        createSunLastTime -= Time.deltaTime;
        if (createSunLastTime <= 0)
        {
            Debug.Log("已经生成了一个阳光");
            PreparedRandomObject();
            createSunLastTime = createSunTime;
        }
    }
   

    public void SunAdd()
    {
        currentSun += 25;
    }
    public int SunCount()
    {
        return currentSun;
    }


    #region 生成对象池
    //复制预制体对象 加入对象池
    GameObject Copy()
    {

        var copy = GameObject.Instantiate(sunPrefabs, transform);
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
        if (groundQueue.Count > 0) //&& !queue.Peek().activeSelf
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
    public GameObject PreparedObject()
    {
        GameObject proparedObject = AvailableObject();

        proparedObject.SetActive(true);

        return proparedObject;
    }
    public GameObject PreparedRandomObject()
    {
        GameObject proparedObject = AvailableObject();
        float sunX = Random.Range(0.0f, 15f);
        proparedObject.transform.position = new Vector2(sunX, 12f);
        proparedObject.SetActive(true);
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
