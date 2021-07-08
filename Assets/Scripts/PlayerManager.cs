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
        thirstSlider.maxValue = thirst;
        hungerSlider.maxValue = hunger;
        StartCoroutine(LoseHungerAndThirstOverTime());
    }

    

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            other.gameObject.SetActive(false);
        }
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
            SetHealth(health);
            SetHunger(hunger);
            SetThirst(thirst);
            //Debug.Log("Hunger: "+hunger+" | "+"Thirst: "+thirst+" | "+"Health: "+health);
            
            yield return new WaitForSeconds(5);
        }

        yield return null;
    }

    private void FixedUpdate()
    {
        SetHealth(health);
        SetHunger(hunger);
        SetThirst(thirst);
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetHunger(float hunger)
    {
        hungerSlider.value = hunger;
    }

    public void SetThirst(float thirst)
    {
        thirstSlider.value = thirst;
    }
}
