using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform player;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deadly")
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }

}