using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    private GameObject playerObject;

    public UnityEngine.UI.Text hp = null;
    public UnityEngine.UI.Text ammo = null;
    public UnityEngine.UI.Text round = null;
    public UnityEngine.UI.Text money = null;
    private PlayerInfo playerInfo;
    private Round roundInfo;
    public string hpMessage;
    public string ammoMessage;
    public string roundMessage;
    public string moneyMessage;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");  //finds player objcect.
        playerInfo = playerObject.GetComponent<PlayerInfo>();  //gets script w/ hp and ammo
        roundInfo = playerObject.GetComponent<Round>();  //gets script w/ hp and ammo
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "Health: " + playerInfo.health;
        ammo.text = "Ammo: " + playerInfo.ammo;
        round.text = "Round: " + roundInfo.round;
        money.text = "Money: $" + playerInfo.money;
        
    }
}
