using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public InventoryObject invObj;
    public ItemObject[] craftableItems, craftingItems;


    public void CraftFire()
    {
        if (invObj.CheckForItem(craftingItems[0], 2) && invObj.CheckForItem(craftingItems[1], 1))
        {
            invObj.RemoveItem(craftingItems[0], 2);
            invObj.RemoveItem(craftingItems[1], 1);
            invObj.AddItem(craftableItems[0], 1);
        }
    }

    public void Cook(Transform player)
    {
        GameObject[] firePlaces = GameObject.FindGameObjectsWithTag("Fire");
        var fireCheck = false;
        for (var i = 0; i < firePlaces.Length; i++)
        {
            if (Vector3.Distance(player.position, firePlaces[i].transform.position) < 3)
            {
                fireCheck = true;
                break;
            }
        }
        if (invObj.CheckForItem(craftingItems[2], 1) && fireCheck)
        {
            invObj.RemoveItem(craftingItems[2], 1);
            invObj.AddItem(craftableItems[1], 1);
        }
    }
}