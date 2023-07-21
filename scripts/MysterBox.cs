using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysterBox : MonoBehaviour
{
   private GameObject door;
    public UnityEngine.UI.Text openText = null;
    public int cost;
    public string message = "Press G to purchase mystery box";
    private bool inArea = false;

    private GameObject playerObject;
    private PlayerInfo playerInfo;
    public GameObject[] powerUps;
    private int probability;

    void Start() {
        message = message + " Cost:\n$ " + cost;
        openText.text = message;
        openText.gameObject.SetActive(false);
        playerObject = GameObject.Find("Player");  //finds player objcect.
        playerInfo = playerObject.GetComponent<PlayerInfo>();  //gets script w/ hp and ammo
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea) {
            if(Input.GetKeyDown(KeyCode.G) && playerInfo.money >= cost){
                playerInfo.money -= cost;
                openText.gameObject.SetActive(false); //remove text from screen

                probability = Random.Range(0,3);

                Instantiate(powerUps[probability], transform.position  + new Vector3(0f, 2f, 0f), Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            openText.text = message;
            inArea = true;
            openText.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            openText.gameObject.SetActive(false);
            inArea = false;
        }
    }
 
    }

