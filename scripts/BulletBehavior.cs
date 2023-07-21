using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float OnscreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
