using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : Singleton<SunManager>
{
    public GameObject sunPrefabs;//阳光模型
    public float createSunTime;// 需要时间
    float createSunLastTime;//距离下一次阳光生成的时间



    private void Start()
    {
        createSunLastTime = createSunTime;
    }


}
