using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutManAttack : MonoBehaviour
{
    float timer =0.1f;
    private int normalBulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        normalBulletDamage = GetComponentInParent<PlantBulletPool>().gameObject.GetComponent<PlantAttributeManagement>().plantAttack;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        transform.Translate(Vector2.right * Time.deltaTime * 10f);
        if(timer < 0)
        {
            GetComponentInParent<PlantBulletPool>().Return(gameObject);
            timer = 0.1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage);
            collision.GetComponent<ZombieAttributeManagement>().WallnutAttack();
        }
    }
}
