using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject playerPos;
    public GameObject objectToSpawn;
    public ItemObject itemInInv;
    public InventoryObject invObj;
    public GameObject smallObjects;

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
            var fire = Instantiate(objectToSpawn, playerPos.transform.position, Quaternion.identity);
            fire.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            fire.transform.parent = smallObjects.transform;
            
            invObj.RemoveItem(itemInInv, 1);
        }
    }
}
