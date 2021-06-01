using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravityScript : MonoBehaviour
{
    public float gravity = -9.81f;

    public void Attract(Transform body){

        Vector3 targetDir = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation; // hält das objekt aufrecht
        body.GetComponent<Rigidbody>().AddForce(targetDir * gravity); // drückt das objekt auf den planeten
    }
}
