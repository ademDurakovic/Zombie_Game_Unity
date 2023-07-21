using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionWater : MonoBehaviour
{
    private float timer;
    public float delay;
    public int damage;
    private PlayerInfo pInfo;
    private GameObject water;
    private float waterLevel;

    void Start() {
        timer = delay;
        water = GameObject.Find("PoisonLake");
        waterLevel = water.transform.position.y;
    }

    void OnTriggerStay(Collider col) {

        if (col.gameObject.tag == "Player") {
            pInfo = col.gameObject.GetComponent<PlayerInfo>();
        }
        if(col.gameObject.transform.position.y < waterLevel && col.gameObject.tag == "Player") {
            timer -= Time.deltaTime;
            if (timer <= 0f  && pInfo != null){
                pInfo.health -= damage;
                timer = delay;
            }
        }

    }

    void OnTriggerExit() {
        timer = delay;
    }

}
