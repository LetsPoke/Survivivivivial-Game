using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public InventoryObject invObj;
    public ItemObject[] craftableItems, craftingItems;
    

    public void CraftItem(int indexOfItemToCraft)
    {
        // Could be abstracted, but I am too lazy to do it now, maybe later
        // If you find this comment: 177013 lmao

        switch (indexOfItemToCraft)
        {
            case 0:
                if (invObj.CheckForItem(craftingItems[0], 2) && invObj.CheckForItem(craftingItems[1], 1))
                {
                    invObj.RemoveItem(craftingItems[0], 2);
                    invObj.RemoveItem(craftingItems[1], 1);
                    invObj.AddItem(craftableItems[0],1);
                }
                break;
            case 1:
                if (invObj.CheckForItem(craftingItems[2], 1))
                {
                    invObj.RemoveItem(craftingItems[2], 1);
                    invObj.AddItem(craftableItems[1],1);
                }
                break;
        }
    }
}
