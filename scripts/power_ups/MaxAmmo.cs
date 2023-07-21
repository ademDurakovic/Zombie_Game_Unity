using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour, PowerUpInterface
{
    private GameObject playerObject;
    private PlayerInfo playerInfo;

    public int ammoAmount;
    public PlayerInfoUI playerUI;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");  //finds player objcect.
        playerInfo = playerObject.GetComponent<PlayerInfo>();  //gets script w/ hp and ammo
        playerUI = playerObject.GetComponent<PlayerInfoUI>();  //gets script w/ hp and ammo
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider col){   // TODO: ADD COLLIDER SO ONLY ON PLAYER COLLIDER.
        if (col.gameObject.tag == "Player") {
            playerInfo.ammo += ammoAmount;  //gives ammo.
            playerUI.ammo.text = "Ammo: " + playerInfo.ammo;
            Destroy(this.gameObject);
        }
    }
}
