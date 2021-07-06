using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceStructure : MonoBehaviour
{
    public GameObject structureToPlace;
    public Transform player;
    public Transform smallObjectsParent;

    public void SpawnStructure()
    {
        var fire = Instantiate(structureToPlace, player.forward*2 + player.position, player.rotation);
        fire.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        fire.transform.parent = smallObjectsParent;
    }
}
