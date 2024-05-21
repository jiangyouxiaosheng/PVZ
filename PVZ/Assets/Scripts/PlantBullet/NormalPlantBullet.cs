using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlantBullet : MonoBehaviour
{
    PlantBulletPool bulletPool;

    private void Start()
    {
        bulletPool = GetComponentInParent<PlantBulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 3f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            //collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(1);
            bulletPool.Return(gameObject);

        }
    }

}
    