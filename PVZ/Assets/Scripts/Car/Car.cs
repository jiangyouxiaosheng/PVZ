using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    float timer=1;
    float addTime;
    float maxTime=1.5f;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -=Time.deltaTime;
        addTime += Time.deltaTime;
        if(timer < 0)
        {
            if(addTime < maxTime)
            {
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Mathf.Lerp(0, 1,addTime / maxTime));
            }
        }
    }
    public void TimerAdd(float i)
    {
        timer += i;
    }

}
