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
    public float createSunTime;// ��Ҫʱ��
    float createSunLastTime;//������һ���������ɵ�ʱ��
    Queue<GameObject> groundQueue = new Queue<GameObject>();
    private Transform thisTransform;
    int size=2;
    public bool dayIsDay;
    
    private void Start()
    {
        thisTransform = transform;
        createSunLastTime = createSunTime;
        Init(thisTransform);
    }


    private void Update()
    {
     
        if (dayIsDay)
        {
            createSunLastTime -= Time.deltaTime;
            if (createSunLastTime <= 0)
            {
                PreparedRandomObject();
                createSunLastTime = createSunTime;
            }
        }
    
    }
   
    public void SunSet(int sun)
    {
        currentSun = sun;
    }
    public void SunAdd(int sun)
    {
        currentSun += sun;
    }
    public bool SunClick(int sun)
    {
        if(currentSun -sun < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public  void SunDown(int sun)
    {
        if(currentSun -sun < 0)
        {
            currentSun = 0;
        }
        else
        {
            currentSun -= sun;
        }
       
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

      
        return avaliableObject;
    }

    //���ÿ��õĶ���
    public GameObject PreparedObject(Vector3 pos)
    {
        GameObject proparedObject = AvailableObject();
        proparedObject.transform.position = pos;
        proparedObject.SetActive(true);

        return proparedObject;
    }
    public GameObject PreparedRandomObject()
    {
        GameObject proparedObject = AvailableObject();
        float sunX = Random.Range(-400f, 400f);
        proparedObject.transform.localPosition = new Vector2(sunX, transform.position.y) ;
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
