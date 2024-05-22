using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    RaycastHit2D hit;
    SpriteRenderer _sprite;
    ShovelUI shovelUI;
    // Start is called before the first frame update
    void Start()
    {
       _sprite = GetComponent<SpriteRenderer>();
        shovelUI = GetComponent<ShovelUI>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (_sprite.enabled) 
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, -1), new Vector3(0, 0, 1), 4f);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<PlantAttributeManagement>() != null && _sprite.enabled != false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.GetComponent<PlantAttributeManagement>().SetDestroyplantMap();
                    _sprite.enabled = false;
                    shovelUI.ShovelImage.SetActive(true);
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _sprite.enabled = false;
                    shovelUI.ShovelImage.SetActive(true);
                }
            }
          
        }

    }
}
