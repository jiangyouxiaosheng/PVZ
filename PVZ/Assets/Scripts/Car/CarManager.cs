using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : Singleton<CarManager>
{
    public GameObject carPrefab;



    private void Start()
    {
   
    }


    public void InstantiateCar()
    {
        
        for(int i = 0; i < 5; i++)
        {
            var car = Instantiate(carPrefab, transform);
            car.GetComponent<Car>().TimerAdd(0.1f*i);
           // car.GetComponent<SpriteRenderer>().enabled = false;
            car.transform.position = new Vector2(-1.75f + i * 0.1f, 2 * i);
        }
    }

}
