using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    private PlayerManager playerMan;
    public InventoryObject invObj;

    public void FuckingEatLikeWhatDoYouExpectThisClassDoesIDK(FoodObject item)
    {
        var gameMan = GameObject.Find("GameManager");
        playerMan = gameMan.GetComponent<PlayerManager>();
        
        if (invObj.CheckForItem(item, 1))
        {
            playerMan.health += item.restoreLifeValue;
            playerMan.thirst += item.restoreThirstValue;
            playerMan.hunger += item.restoreFoodValue;
            invObj.RemoveItem(item,1);
        }
    }
}
