using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public int delay;
    private int zombieSpawnsLeft = 5;
    private float timer;
    private int originalSpawns;

    void Start() {
        timer = delay;
        originalSpawns = zombieSpawnsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && zombieSpawnsLeft > 0) {
            this.spawnZombie();
            timer = delay;
        } 

    }

    private void spawnZombie() {
        GameObject zombie = Instantiate<GameObject>(enemy, this.transform.position, this.transform.rotation);
        zombieSpawnsLeft--;
    }

    public void reset(int zombies) {
        this.zombieSpawnsLeft = zombies;

    }
}
