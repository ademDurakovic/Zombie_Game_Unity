using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioTrigger : MonoBehaviour
{
    public AudioClip audioFile;
    private AudioSource audioPlayer = null;
    public bool playOnlyOnce = true;
    private bool hasPlayed = false;

    //timer to avoid quick repeat plays
    public float multiPlayDelay = 1;
    private double timer = 0.0;
     

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();
        timer = multiPlayDelay;

        if (audioPlayer == null) {

            Debug.LogWarning("AudioSource is missing");
        }

        if (audioFile == null) {
            
            Debug.LogWarning("no AudioFile provided");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Player") && (timer >= multiPlayDelay)
                && ((playOnlyOnce && !hasPlayed) || !playOnlyOnce))
        {
            
            if (audioFile != null && audioPlayer != null)
                audioPlayer.PlayOneShot (audioFile);

            timer = 0;
            hasPlayed = true;
        }
    }
}
