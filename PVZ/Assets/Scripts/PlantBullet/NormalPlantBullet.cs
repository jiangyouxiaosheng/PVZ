using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlantBullet : MonoBehaviour
{
    PlantBulletPool bulletPool;

    public GameObject normalBullet;
    public GameObject fireBullet;
    public int normalBulletDamage;
    public int fireBulletDamage;

    bool isFire;
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
            if (isFire)
            {
                collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(fireBulletDamage);
               
            }
            else
            {
                collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage);
                collision.GetComponent<ZombieAttributeManagement>().moveSpeedDownTime = 5f;
            }

            bulletPool.Return(gameObject);
            isFire = false;
            normalBullet.SetActive(true);
            fireBullet.SetActive(false);
        }

        if (collision.gameObject.tag == "Plant")
        {
            if(collision.gameObject.GetComponent<Torchwood>()!=null)
            {
                fireBullet.SetActive(true);
                isFire = true;
            }
        }
    }


}
    