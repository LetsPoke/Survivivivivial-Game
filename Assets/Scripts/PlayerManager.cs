using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health, hunger, thirst;
    
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
}
