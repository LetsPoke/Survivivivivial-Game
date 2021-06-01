using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class ObjektGravityScript : MonoBehaviour
{
    PlanetGravityScript planet;

    void Awake() {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetGravityScript>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate() {
        planet.Attract(transform);
    }
    
    
}
