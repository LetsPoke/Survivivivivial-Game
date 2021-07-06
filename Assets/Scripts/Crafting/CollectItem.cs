using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private bool inRange, choppey = false;
    public GameObject Trigger;
<<<<<<< HEAD
    public GameObject holz;

    // private void Update() {
    //     ChoppedyChopChop();
    //}
=======
    private bool inRange = false;


>>>>>>> 790adde057f822206419d4e2a251c9ff518c8451
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
            holz.SetActive(true);
        }
    }
}
