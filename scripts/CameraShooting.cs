using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShooting : MonoBehaviour
{
    private GameObject cameraObject;
    private GameObject playerObject;
    public Rigidbody Bullet;
    public float BulletSpeed = 75f;
    private bool _isShooting;
    public AudioClip throwSound = null;
    public PlayerInfo playerInfo;
    // Start is called before the first frame update

    void Start()
    {
        this.cameraObject = GameObject.Find("Main Camera");
        this.playerObject = cameraObject.transform.parent.gameObject;

        this.playerInfo = this.playerObject.GetComponent<PlayerInfo>();  // need this to know hm ammo user has.
    }

    void Update()
    {
        _isShooting |= Input.GetKeyDown(KeyCode.Space);
    }
    void FixedUpdate()
    {
        if (_isShooting && playerInfo.ammo > 0)
        {
            Rigidbody newBullet = Instantiate(Bullet, this.playerObject.transform.position + new Vector3(0,0.75f,0), this.transform.rotation * this.Bullet.transform.rotation);

            Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), this.playerObject.GetComponent<Collider>());

            newBullet.velocity = this.transform.forward * BulletSpeed;

            if (throwSound != null)
            {
                AudioSource audioPlayer = newBullet.GetComponent<AudioSource>();
                if (audioPlayer != null)
                {
                    audioPlayer.PlayOneShot(throwSound);
                }
                else
                {
                    Debug.LogWarning("Your" + newBullet.gameObject.name + "prefab must have an AudioSource component");
                }
            }
            playerInfo.ammo--;
        }
        _isShooting = false;
    }

}
