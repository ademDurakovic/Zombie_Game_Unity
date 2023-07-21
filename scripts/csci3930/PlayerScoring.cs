using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{
    private int currentScore = 0;
    private GameObject playerObject;
    private string scoreMessage = "Score: ";
    public UnityEngine.UI.Text scoreText = null;
    private AudioSource audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // gets player object
        audioPlayer = this.GetComponent<AudioSource>(); // gets the audio source component tied to the player
        
    }

    // Update is called once per frame
    void Update()
    {
        //updates the gui score text 
        scoreText.text = scoreMessage + currentScore;
    }

    void OnCollisionEnter(Collision col) { // player collides with the scoring object
        
        if (col.gameObject.tag == "ScoreObject") // the object has the tag "ScoreObject"
        {
            increaseScore(col); // increase score function
        }
    }

    private void increaseScore (Collision col) {
        ObjectScoring objectScript = col.gameObject.GetComponent<ObjectScoring>(); // get scoring script from object
        

        if (objectScript != null)
        {
            currentScore += objectScript.value; // adds the value of the object to the players score

            if (audioPlayer != null)
            {
                audioPlayer.PlayOneShot(objectScript.collectSound); //plays collection sound
            }

            if (objectScript.destroyOnCollision) {
                Destroy(col.gameObject); // destroys the object
            }
        }

    }
}
