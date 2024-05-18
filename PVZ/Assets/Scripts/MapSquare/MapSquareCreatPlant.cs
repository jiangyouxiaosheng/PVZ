using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSquareCreatPlant : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public PlantDataList_SO plantDatalist;
    private PlantData_SO plantData;
    bool thisSquareIsUse;
    private Transform plantParents;
   // public List<GameObject> plantPrefabs;


    private void Start()
    {
        plantParents =GameObject.Find("PlantsParent").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
    }
    public void Init()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
    }
    public void PlantPreview(int plantID)
    {
        if (thisSquareIsUse == false)
        {
            plantData = plantDatalist.GetInventoryItem(plantID);
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            spriteRenderer.sprite = plantData.plantImage;
            spriteRenderer.color = new Color(1, 1, 1, 100 / 255f);

        }

    }
    public void InstantiatePlant(int plantID)
    {
       if(thisSquareIsUse == false)
        {
            thisSquareIsUse = true;
            var plant = Instantiate(plantDatalist.GetInventoryItem(plantID).plantPrefabs, plantParents);
            plant.transform.position = transform.position;
            
        }
   
    }

}
