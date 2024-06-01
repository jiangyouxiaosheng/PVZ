using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterGirlBoomBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(30);
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
