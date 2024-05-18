using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlantImage : MonoBehaviour
{
    private SpriteRenderer plantSprite;
    private PlantDataList_SO plantDatas;
    RaycastHit2D hit;
    private void Start()
    {
        plantSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            hit = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y,-1), new Vector3(0, 0, 1), 4f);

            if (hit.collider && hit.collider.gameObject.GetComponent<MapSquareCreatPlant>()!=null)
            {
                hit.collider.gameObject.GetComponent<MapSquareCreatPlant>().PlantPreview(001);
            }
          
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (hit.collider && hit.collider.gameObject.GetComponent<MapSquareCreatPlant>() != null)
            {
                hit.collider.gameObject.GetComponent<MapSquareCreatPlant>().InstantiatePlant(001);
            }
        
            plantSprite.enabled = false;
        }




    }
    
    public void FollowMousePos()
    {
     
        plantSprite.enabled = true;
    }
}