using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, hunger, thirst;
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;


    void Start()
    {
        StartCoroutine(LoseHungerAndThirstOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        
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
