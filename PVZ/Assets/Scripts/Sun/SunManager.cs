using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SunManager : Singleton<SunManager>
{
    [SerializeField]
    private int currentSun;


    [SerializeField]
    private GameObject sunPrefabs;//����ģ��
    [SerializeField]
    private float createSunTime;// ��Ҫʱ��
    float createSunLastTime;//������һ���������ɵ�ʱ��
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
            Debug.Log("�Ѿ�������һ������");
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


    #region ���ɶ����
    //����Ԥ������� ��������
    GameObject Copy()
    {

        var copy = GameObject.Instantiate(sunPrefabs, transform);
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

    //���ÿ��õĶ���
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


    //�����ù��Ķ��󷵻ض����(��������д��ͬһ������)
    public void Return(GameObject gameObject)
    {
        gameObject.SetActive(false);
        groundQueue.Enqueue(gameObject);

    }

    #endregion






}
