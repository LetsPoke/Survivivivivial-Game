using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject Trigger;
    public InventoryObject invObj;
    public ItemObject item;
    
    private bool inRange = false;

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player"){
            //Debug.Log("inrange");
            inRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
        //Debug.Log("not mehr inrange");
        inRange = false;
        }
    }

    public void ChoppedyChopChop(){
        if(inRange){
            //Debug.Log("Choppedy");
            Trigger.SetActive(false);
            invObj.AddItem(item, 2);
        }
    }



    

}
