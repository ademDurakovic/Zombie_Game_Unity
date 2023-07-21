using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTeleportTrigger : MonoBehaviour
{
    public GameObject teleportTarget = null;
    public AudioClip teleportSound = null;

    private Vector3 targetPos;
    private Quaternion targetRot;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = teleportTarget.transform.position;
        targetRot = teleportTarget.transform.rotation;
    }

    void OnTriggerEnter(Collider col)
    {
        if ((teleportTarget != null) && (col.gameObject.tag == "Player"))
        {
            col.transform.position = targetPos;
            col.transform.rotation = targetRot;

            if(teleportSound != null) {
                AudioSource audioPlayer = col.GetComponent<AudioSource>();

                if (audioPlayer != null)
                    audioPlayer.PlayOneShot (teleportSound);
            }
        }
    }
}
