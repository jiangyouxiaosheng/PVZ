using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlantBullet : MonoBehaviour
{
    PlantBulletPool bulletPool;
   
    public GameObject normalBullet;
    public GameObject fireBullet;
    private int normalBulletDamage;
    private int fireBulletDamage;
    public GameObject destroyThis;
    private CircleCollider2D _circleCollider=>GetComponent<CircleCollider2D>();
    private AudioSource _audioSource =>GetComponent<AudioSource>();
    bool isFire;
    private void Start()
    {
        bulletPool = GetComponentInParent<PlantBulletPool>();
        normalBulletDamage = GetComponentInParent<PlantBulletPool>().gameObject.GetComponent<PlantAttributeManagement>().plantAttack;
    }

    private void OnEnable()
    {
        VoiceReady();
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
            _audioSource.Play();
            if (isFire)
            {
                collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage+2);
                Instantiate(destroyThis,transform.position, Quaternion.identity);
                normalBullet.SetActive(false);
            }
            else
            {
                collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage);
                collision.GetComponent<ZombieAttributeManagement>().moveSpeedDownTime = 5f;
                Instantiate(destroyThis, transform.position, Quaternion.identity);
            }

           
            VoicePlay();
            StartCoroutine(WaitVoice());

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
    IEnumerator WaitVoice()
    {
        yield return new WaitForSeconds(1f);
        bulletPool.Return(gameObject);
    }
    void VoicePlay()
    {
        normalBullet.SetActive(false);
        _circleCollider.enabled = false;
    }

    void VoiceReady()
    {
        normalBullet.SetActive(true);
        fireBullet.SetActive(false);
        _circleCollider.enabled =true;
        isFire = false;
    }


}
    