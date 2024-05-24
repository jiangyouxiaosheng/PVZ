using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHpZeroAttack : MonoBehaviour
{

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("!11");
        if(collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieAttributeManagement>().ZombieIsDie();
        }
    }
}
