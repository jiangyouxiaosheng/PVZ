using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawPlantImage : MonoBehaviour
{
    private SpriteRenderer plantSprite;
    public PlantDataList_SO plantDatas;
    PlantData_SO plantData;
    private bool isCanClick;
    private GameObject slot;
    RaycastHit2D hit;
    public LayerMask layerMask;
    private AudioSource _audioSource => GetComponent<AudioSource>();
    private void Start()
    {
        plantSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isCanClick)
        {

            if (plantData.plantID == 1008)
            {
                layerMask = 0 << 8|1<<7;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(transform.position.x, transform.position.y, -2);
                hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, -1), new Vector3(0, 0, 1), 4f,layerMask);
                //Debug.LogError(hit.collider);
                if (plantData.plantID != 1003)
                {
                    
                    if ((hit.collider && hit.collider.gameObject.GetComponent<MapSquareCreatPlant>() != null))
                    {
                        hit.collider.gameObject.GetComponent<MapSquareCreatPlant>().PlantPreview(plantData.plantID);
                    }

                }
                else
                {
                    MapCreate.Instance.isCanSet = true;
                }

               
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                layerMask = 1 << 8 | 1 << 7;
                if (plantData.plantID != 1003)
                {
                    if (hit.collider && hit.collider.gameObject.GetComponent<MapSquareCreatPlant>() != null && plantSprite.enabled != false)
                    {

                       
                        hit.collider.gameObject.GetComponent<MapSquareCreatPlant>().InstantiatePlant(plantData.plantID,slot);
                   

                    }
                }
                else
                {
                    if (hit.collider && hit.collider.gameObject.GetComponent<Peashooter>() != null && plantSprite.enabled != false)
                    {
                       
                        hit.collider.gameObject.GetComponent<Peashooter>().attributeManagement.SetGatlingPea(slot);
                    }

                }
                MapCreate.Instance.isCanSet = false;
                plantSprite.enabled = false;
                MapCreate.Instance.MapFalse();
                isCanClick = false;
            }

        }


    }
    
    public void FollowMousePos(int ID,GameObject obj)
    {
        isCanClick = true;
        plantSprite.enabled = true;
        plantData = plantDatas.GetInventoryItem(ID);
        plantSprite.sprite = plantData.plantImage;
        transform.localScale = Vector3.one;
        slot = obj;
        _audioSource.Play();
    }
}
