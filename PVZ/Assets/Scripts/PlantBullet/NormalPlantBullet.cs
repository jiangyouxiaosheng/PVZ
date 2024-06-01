using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlantBullet : MonoBehaviour
{
    PlantBulletPool bulletPool;

    public GameObject normalBullet;
    public GameObject fireBullet;
    public GameObject boomBullet;
    public GameObject boomDestroyThis;
    public bool isPeaShooterGirl;
    bool isBoomBullet;
    private int normalBulletDamage;
    public GameObject destroyThis;

    float returnTime = 10f;
    private CircleCollider2D _circleCollider => GetComponent<CircleCollider2D>();
    private AudioSource _audioSource => GetComponent<AudioSource>();
    bool isFire;
    private void Start()
    {
        bulletPool = GetComponentInParent<PlantBulletPool>();
        normalBulletDamage = GetComponentInParent<PlantBulletPool>().gameObject.GetComponent<PlantAttributeManagement>().plantAttack;
    }

    private void OnEnable()
    {
        returnTime = 10;
        VoiceReady();
    }

    // Update is called once per frame
    void Update()
    {
        returnTime -= Time.deltaTime;
        if (returnTime <= 0)
        {
            bulletPool.Return(gameObject);
        }
        transform.Translate(Vector2.right * Time.deltaTime * 3f);
     
    }

    public void IsPeaShooterGirl(bool force)
    {
        isPeaShooterGirl = force;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Zombie")
        {
            _audioSource.Play();
           
            if(isBoomBullet)
            {
                Instantiate(boomDestroyThis, transform.position, Quaternion.identity);
                boomBullet.SetActive(false);
            }
            else
            {
                if (isFire)
                {
                    collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage + 2);
                    Instantiate(destroyThis, transform.position, Quaternion.identity);
                    normalBullet.SetActive(false);
                }
                else if (isFire == false)
                {
                    collision.GetComponent<ZombieAttributeManagement>().ZombieIsInjury(normalBulletDamage);
                    collision.GetComponent<ZombieAttributeManagement>().moveSpeedDownTime = 5f;
                    Instantiate(destroyThis, transform.position, Quaternion.identity);
                }
            } 
            VoicePlay();
            StartCoroutine(WaitVoice());

        }

        if (collision.gameObject.tag == "Plant"&&isBoomBullet==false)
        {
            if (collision.gameObject.GetComponent<Torchwood>() != null)
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
        if (isPeaShooterGirl)
        {
            if (gameObject.GetComponentInParent<PeaShooterGirl>().shootNum >= 4)
            {
                gameObject.GetComponentInParent<PeaShooterGirl>().shootNum = 0;
                normalBullet.SetActive(false);
                boomBullet.SetActive(true);
                _circleCollider.enabled = true;
                isBoomBullet = true;
            }
            else
            {
                normalBullet.SetActive(true);
                fireBullet.SetActive(false);
                boomBullet.SetActive(false);
                _circleCollider.enabled = true;
                isFire = false;
                isBoomBullet =false;
            }
        }
        else
        {
            isBoomBullet = false;
            normalBullet.SetActive(true);
            fireBullet.SetActive(false);
            boomBullet.SetActive(false);
            _circleCollider.enabled = true;
            isFire = false;
        }
     
    }


}
