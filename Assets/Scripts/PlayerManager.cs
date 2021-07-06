using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100, hunger = 100, thirst = 100;
    public InventoryObject inventory;
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    
    void Start()
    {
        healthSlider.maxValue = health;
        hungerSlider.maxValue = thirst;
        thirstSlider.maxValue = hunger;
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
                thirst-=2;
            }
            
            if (hunger == 0)
            {
                health--;
            }
            else
            {
                hunger--;
            }
            
            //Debug.Log("Hunger: "+hunger+" | "+"Thirst: "+thirst+" | "+"Health: "+health);
            SetHealth(health);
            SetHunger(hunger);
            SetThirst(thirst);
            yield return new WaitForSeconds(5);
        }

        yield return null;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetHunger(float thirst)
    {
        hungerSlider.value = thirst;
    }

    public void SetThirst(float hunger)
    {
        thirstSlider.value = hunger;
    }
}
