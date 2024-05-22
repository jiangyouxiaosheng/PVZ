using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelUI : MonoBehaviour
{
    public GameObject ShovelImage;
    private Shovel shovel;

    private void Start()
    {
        shovel = GetComponent<Shovel>();
    }
    public void ShovelSetactive()
    {
        ShovelImage.SetActive(false);
        shovel.GetComponent<SpriteRenderer>().enabled = true;
    }
}
