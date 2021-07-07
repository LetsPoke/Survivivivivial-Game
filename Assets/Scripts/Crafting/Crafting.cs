using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public InventoryObject invObj;
    public ItemObject[] craftableItems;

    public void CraftItem(int indexOfItemToCraft)
    {
        // Could be abstracted, but I am too lazy to do it now, maybe later
        // If you find this comment: 177013 lmao

        switch (indexOfItemToCraft)
        {
            case 0:
                
                break;
            case 1:
                break;
        }
    }
}
