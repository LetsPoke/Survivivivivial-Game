using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, hunger, thirst;
    public InventoryObject inventory;
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    
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

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetMaxHunger(int thirst)
    {
        hungerSlider.maxValue = thirst;
        hungerSlider.value = thirst;
    }

    public void SetMaxThirst(int hunger)
    {
        thirstSlider.maxValue = hunger;
        thirstSlider.value = hunger;
    }
}
