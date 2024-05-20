using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefabs;//�ӵ�ģ��

    Queue<GameObject> groundQueue = new Queue<GameObject>();
    private Transform thisTransform;
    int size = 10;




    #region ���ɶ����
    //����Ԥ������� ��������
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(bulletPrefabs, transform);
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
        proparedObject.transform.position = pos.position;
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