using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : Singleton<SunManager>
{
    public GameObject sunPrefabs;//����ģ��
    public float createSunTime;// ��Ҫʱ��
    float createSunLastTime;//������һ���������ɵ�ʱ��



    private void Start()
    {
        createSunLastTime = createSunTime;
    }


}
