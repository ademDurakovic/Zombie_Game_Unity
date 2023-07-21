using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public float jumpMultiplier;
    private bool insideArea;
    private AudioSource audioSource = null;
    public AudioClip audioFile;
    private float originalJump;
    private GameObject player;
    private PlayerBehavior playerJump;
    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        if (audioSource == null) {

            Debug.LogWarning("AudioSource is missing");
        }

        // gets player object and the player behavior script attached to it
        player = GameObject.FindGameObjectWithTag("Player");
        playerJump = player.GetComponent<PlayerBehavior>();
        originalJump = playerJump.JumpVelocity; // saves current jump velocity
    }

    void OnTriggerEnter(Collider col) {
        if ( col.CompareTag("Player") ) {
            playerJump.JumpVelocity *= jumpMultiplier; // multiplies the original jump velocity
            insideArea = true; 

        }
    }

    void OnTriggerExit(Collider col) {
        if ( col.CompareTag("Player") ) {
            playerJump.JumpVelocity = originalJump; // on exit the jump velocity goes back to original value
            insideArea = false;
        }
    }

    void Update() {
        // update method to check if the player is jumping, inside the area, and grounded so the sound only plays once when the player jumps
        if(Input.GetKeyDown(KeyCode.J) && insideArea && playerJump.IsGrounded()) {
            audioSource.PlayOneShot(audioFile);
        }
    }
}
