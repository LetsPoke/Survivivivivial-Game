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

    public void Cook()
    {
        if (invObj.CheckForItem(craftingItems[2], 1))
        {
            invObj.RemoveItem(craftingItems[2], 1);
            invObj.AddItem(craftableItems[1], 1);
        }
    }
}