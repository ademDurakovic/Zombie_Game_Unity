using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour, PowerUpInterface
{
    private GameObject player;
    private Round roundScript;
    private PlayerInfo playerInfo;

    void Start()
    {
        player = GameObject.Find("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
        roundScript = player.GetComponent<Round>();
    }

    public void OnTriggerEnter(Collider col){  
        if (col.gameObject.tag == "Player") {
            playerInfo.money += 400;
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

            Destroy(this.gameObject);

            foreach (GameObject zom in zombies) {
                roundScript.totalKills++;

                Destroy(zom, 0.5f);
            }
        }
    }
}

