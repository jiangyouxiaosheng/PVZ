using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private float sunDownTime;
    [SerializeField]
    private float sunRemainingTime;
    private float sunRemainingTimeRecord;
    bool isClicked;
    public bool isDestroy;
    private void Awake()
    {
        sunRemainingTimeRecord = sunRemainingTime;
      
    }
    private void OnEnable()
    {
         sunRemainingTime = sunRemainingTimeRecord;
        if (isDestroy)
        {
            sunDownTime = 1;
        }
        else
        {
            sunDownTime = Random.Range(4f, 12f);
        }
        

    }
  

    private void Update()
    {

        if (isClicked==false)
        {
            sunDownTime -= Time.deltaTime;
            if (sunDownTime > 0)
            {
                 transform.Translate(Vector2.down * Time.deltaTime * 50f);

            }
            else
            {
                sunRemainingTime -= Time.deltaTime;
                if (sunRemainingTime <= 0)
                {
                    if (isDestroy == false)
                    {
                        SunManager.Instance.Return(gameObject);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
            
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, UIManager.Instance.sunCountText.transform.position, 500 * Time.deltaTime);
            if (Vector2.Distance(transform.position, UIManager.Instance.sunCountText.transform.position) <= 0.5f)
            {
                if (isDestroy == false)
                {
                    SunManager.Instance.Return(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                SunManager.Instance.SunAdd();
                isClicked = false;
            }
        }
       
    }

    public void ClickCollect()
    {
        isClicked = true;
    }







}
