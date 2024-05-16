using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
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
                Instantiate(mapSquare, new Vector3(1.9f * i, 2 * j, 0), Quaternion.identity,transform);

            }
        }

    }
}
