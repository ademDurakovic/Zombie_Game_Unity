using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sounds : MonoBehaviour
{
    private AudioSource audioPlayer = null;
    public AudioClip healthSound = null;
    public AudioClip nukeSound = null;
    public AudioClip maxAmmoSound = null;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "health"){
            //play the sound of the collider.
            audioPlayer.PlayOneShot(healthSound);
        }
        else if(col.gameObject.tag == "nuke"){
            audioPlayer.PlayOneShot(nukeSound);
        }

        else if(col.gameObject.tag == "ammo"){
            audioPlayer.PlayOneShot(maxAmmoSound);
        }

        
    }
}
