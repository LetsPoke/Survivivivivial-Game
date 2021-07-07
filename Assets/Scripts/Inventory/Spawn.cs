using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private Transform playerPos;
    
    public GameObject itemToSpawn;
    public ItemObject itemInInv;
    public InventoryObject invObj;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SpawnItem()
    {
        var spawnable = false;
        for (int i = 0; i < invObj.Container.Count; i++)
        {
            if (invObj.Container[i].item == itemInInv)
            {
                spawnable = true;
            }
        }

        if (spawnable)
        {
            Instantiate(itemToSpawn, playerPos.position, Quaternion.identity);
        }
    }
}
