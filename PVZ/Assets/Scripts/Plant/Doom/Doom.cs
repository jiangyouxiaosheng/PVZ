using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doom : MonoBehaviour
{
    public PlantAttributeManagement attributeManagement;
    public GameObject obj;
    public GameObject obj1;
    float timer = 1f;
    private void Awake()
    {
        attributeManagement = GetComponent<PlantAttributeManagement>();
        StartCoroutine(VoicePlay());
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            
            ZombieManager.Instance.AllZombieDamage();
            obj.SetActive(false);
            obj1.SetActive(true);
        
            StartCoroutine(DestroyObj());
        }

    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(2f);
        attributeManagement.SetDestroyplantMap();


    }
    IEnumerator VoicePlay()
    {
        yield return new WaitForSeconds(timer);
        VoiceManager.Instance.Doom();
    }
  
}
