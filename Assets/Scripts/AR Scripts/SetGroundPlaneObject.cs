using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGroundPlaneObject : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;
    public GameObject fire;
    
    void Awake() {
        player.SetActive(true);
        tree.SetActive(false);
        fire.SetActive(false);
    }

    
    public void ChangeObject(){
        if(player.activeSelf){
        player.SetActive(false);
        tree.SetActive(true);
        fire.SetActive(false);
        return;
        }

        if(tree.activeSelf){
        player.SetActive(false);
        tree.SetActive(false);
        fire.SetActive(true);
        return;
        }

        if(fire.activeSelf){
        player.SetActive(true);
        tree.SetActive(false);
        fire.SetActive(false);
        return;
        }
    }
}
