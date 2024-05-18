using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : Singleton<MapCreate>
{
    public List<GameObject> mapPosList = new List<GameObject>();
    private int x = 8, y = 4;
    public GameObject mapSquare;
   

    private void Start()
    {
        MapCreateMethod();
    }

    public void MapCreateMethod()
    {
        for(int i = 0; i <= x; i++)
        {
            for(int j = 0; j <= y; j++)
            {
                var mapPos =  Instantiate(mapSquare, new Vector3(1.9f * i, 2 * j, 0), Quaternion.identity,transform);
                mapPosList.Add(mapPos);
                mapPos.gameObject.SetActive(false);
             
            }
        }

    }

    private void Update()
    {
     
    }
    public void MapFalse()
    {
        for(int i = 0;i < mapPosList.Count; i++)
        {
            mapPosList[i].gameObject.SetActive(false);
        }
    }


    public void MapTrue()
    {
        for (int i = 0; i < mapPosList.Count; i++)
        {
            mapPosList[i].SetActive(true);
        }
    }
}
