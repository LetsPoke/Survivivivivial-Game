using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health, hunger, thirst;
    public InventoryObject inventory;
    void Start()
    {
        StartCoroutine(LoseHungerAndThirstOverTime());
    }

    

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    private IEnumerator LoseHungerAndThirstOverTime()
    {
        while (health > 0)
        {
            if (thirst == 0)
            {
                health--;
            }
            else
            {
                thirst--;
            }
            
            if (hunger == 0)
            {
                health--;
            }
            else
            {
                hunger--;
            }
            
            Debug.Log("Hunger: "+hunger+" | "+"Thirst: "+thirst+" | "+"Health: "+health);
            yield return new WaitForSeconds(1);
        }

        yield return null;
    }
}
