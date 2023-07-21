using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{

    public int round = 1;
    public int totalKills = 0;
    private int totalZombs = 5;
    public List<Spawner> spawners = new List<Spawner>();
    public PlayerInfo playerScript;
    private int numSpawners;
    private int killsPerRound;

    // Update is called once per frame
    void Awake(){
        playerScript = this.GetComponent<PlayerInfo>();
        numSpawners = spawners.Count;
        killsPerRound = numSpawners * totalZombs;
    }

    void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
    
        if (totalKills == round * killsPerRound) {  
            round += 1;
            if(playerScript.bulletDamage > 15){
                playerScript.bulletDamage -= 3;
            }
            
            foreach(Spawner spawner in spawners){
                spawner.reset(totalZombs);
            }
        }
    }

}