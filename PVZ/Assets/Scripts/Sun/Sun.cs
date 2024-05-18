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
    private void Awake()
    {
        sunRemainingTimeRecord = sunRemainingTime;
        sunDownTime = Random.Range(4, 13);
    }
    private void OnEnable()
    {
         sunRemainingTime = sunRemainingTimeRecord;
         sunDownTime = Random.Range(4,13);
     

    }
  

    private void Update()
    {

        if (isClicked==false)
        {
            sunDownTime -= Time.deltaTime;
            if (sunDownTime > 0)
            {
                 transform.Translate(Vector2.down * Time.deltaTime * 1f);

            }
            else
            {
                sunRemainingTime -= Time.deltaTime;
                if (sunRemainingTime <= 0)
                {
                    SunManager.Instance.Return(gameObject);
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(UIManager.Instance.sunCountText.transform.position), 20 * Time.deltaTime);
            if (Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint( UIManager.Instance.sunCountText.transform.position)) <= 0.5f)
            {
                SunManager.Instance.Return(gameObject);
                SunManager.Instance.SunAdd();
            }
        }
       
    }

    public void ClickCollect()
    {
        isClicked = true;
      
    
    }







}