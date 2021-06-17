using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerItem : MonoBehaviour
{

    private PlayerManager player;
    public GameObject healthEffect;
    public int healthBoost;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    public void Use() {
        Instantiate(healthEffect, player.transform.position, Quaternion.identity);
        player.health += healthBoost;
        Destroy(gameObject);
    }
}
