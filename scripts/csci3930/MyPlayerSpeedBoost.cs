using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerSpeedBoost : MonoBehaviour
{

    private float timer;
    private bool superFast = false;
    private float originalSpeed = 6f;

    private float boostDuration;
    private AudioSource audioPlayer = null;

    private string playerName = "";
    private PlayerBehavior script;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        audioPlayer = this.GetComponent<AudioSource>();

        //GameObject playerObject = this.gameObject;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if(playerObject != null) {
            script = playerObject.GetComponentInChildren<PlayerBehavior>();
        }

        if (script != null && playerObject != null) {
            playerName = playerObject.name;
            originalSpeed = script.MoveSpeed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (script != null && superFast && (timer>boostDuration)) {
            superFast = false;
            script.MoveSpeed = originalSpeed;
        }
    }

    public void OnTriggerEnter(Collider col) {

        if(col.gameObject.tag == "SpeedBoost") {

            boostSpeed (col);

        }
    }

    private void boostSpeed(Collider col) {

        //return if no PlayerBehavior script exists
        if (!script)
            return;

        AudioClip playSound = null;
        ObjectSpeedBoost objSpeedScript = col.gameObject.GetComponent<ObjectSpeedBoost>();

        if (objSpeedScript != null) {
            Debug.Log("Boosting Speed");

            timer = 0.0f;

            float speedMultiplier = objSpeedScript.speedMultiplier;
            boostDuration = objSpeedScript.speedBoostDuration;

            superFast = true;

            script.MoveSpeed = script.MoveSpeed * speedMultiplier;

            if(objSpeedScript.destroyOnCollision) 
                Destroy(col.gameObject);

            playSound = objSpeedScript.speedBoostSound;

        }
        if(playSound != null) {
            if (audioPlayer != null) {
                audioPlayer.PlayOneShot(playSound);
            }
        }

    }


}
