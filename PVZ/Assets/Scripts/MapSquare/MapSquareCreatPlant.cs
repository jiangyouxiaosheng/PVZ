using Spine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapSquareCreatPlant : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public PlantDataList_SO plantDatalist;
    private PlantData_SO plantData;
    public bool thisSquareIsUse;
    public bool isHavePumpkin;
    private Transform plantParents;
   // public List<GameObject> plantPrefabs;
    

    private void Start()
    {
        plantParents =GameObject.Find("PlantsParent").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (thisSquareIsUse&&plantData.plantID!=1008)
        {
            Init();
        }
        if(thisSquareIsUse && isHavePumpkin)
        {
            Init();
        }

    }
    public void Init()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
       
    }
    public void PlantPreview(int plantID)
    {
        if(isHavePumpkin==false)
        {
            plantData = plantDatalist.GetInventoryItem(plantID);
            transform.localScale = Vector3.one;
            spriteRenderer.sprite = plantData.plantImage;
            spriteRenderer.color = new Color(1, 1, 1, 100 / 255f);
        }
        if (thisSquareIsUse == false)
        {
            plantData = plantDatalist.GetInventoryItem(plantID);
            transform.localScale = Vector3.one;
            spriteRenderer.sprite = plantData.plantImage;
            spriteRenderer.color = new Color(1, 1, 1, 100 / 255f); 
        }

    }
    public void InstantiatePlant(int plantID)
    {
       
        if (isHavePumpkin == false&& plantData.plantID ==1008)
        {
            isHavePumpkin = true;
            var plant = Instantiate(plantDatalist.GetInventoryItem(plantID).plantPrefabs, plantParents);
            plant.transform.position = transform.position;
            MapCreate.Instance.destroyPumkin.Add(plant, this.gameObject);
            //GameManager.Instance.plantList.Add(plant);
        }
       if(thisSquareIsUse == false && plantData.plantID != 1008)
       {
           
            thisSquareIsUse = true;
         
            var plant = Instantiate(plantDatalist.GetInventoryItem(plantID).plantPrefabs, plantParents);
            plant.transform.position = transform.position;
            MapCreate.Instance.destroyPlant.Add(plant, this.gameObject);
            //GameManager.Instance.plantList.Add(plant);

        }
   
    }

    public void DestroyPumpkin()
    {

        isHavePumpkin = false;

    }
    public void DestroyPlant()
    {
        Init();
        thisSquareIsUse = false;
       
    }

}
