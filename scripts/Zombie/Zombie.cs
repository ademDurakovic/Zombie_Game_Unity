using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float delay;
    public int health;
    public int damage;
    private float timer;
    public int killMoney;

    private GameObject player;
    private PlayerInfo pScript;
    private Round roundScript;
    public float probability;

    public GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        player = GameObject.Find("Player");
        pScript = player.GetComponent<PlayerInfo>();
        roundScript = player.GetComponent<Round>();
        damage = 10;

    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Bullet") {
            health = health - pScript.bulletDamage;
        }
        else if (col.gameObject.tag == "Player"){
            pScript.health -= damage;
        }

        if(health <= 0) {
            roundScript.totalKills++;
            pScript.money += killMoney;
            Destroy(this.gameObject);
            probability = Random.value; //makes int from 0.0 to 1.0. not inclusive of 1

            if(probability > .70){
                if(probability < .75){Instantiate(powerUps[0], transform.position  + new Vector3(0f, 1f, 0f), Quaternion.identity);}
                else if(probability < .85){ Instantiate(powerUps[1], transform.position  + new Vector3(0f, 1f, 0f), Quaternion.identity); }
                else if(probability < .93) {Instantiate(powerUps[2], transform.position  + new Vector3(0f, 1f, 0f), Quaternion.identity);}
                else{
                    Instantiate(powerUps[3], transform.position  + new Vector3(0f, 1f, 0f), Quaternion.identity);
                }
            }

            

        }
        
    }

    void OnCollisionStay(Collision col) {
        
        if (col.gameObject.tag == "Player"){
            timer -= Time.deltaTime;
            if(timer <= 0f) {
                pScript.health -= damage;
                timer = delay;
            }
        }
    }
}
