using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private Vector3 mapPos;
    void Start()
    {
        transform.position = mapPos;
    }

 
}
