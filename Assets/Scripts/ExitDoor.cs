using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ExitDoor : MonoBehaviour {
    
    //TODO idea is that: on top of level, make a door has a health and player try to break for get out
    //TODO problem is that: breake animations and last touch of player can make break door and go out in same jump
    public float health = 20;
    
    // Update is called once per frame

    
    void OnTriggerEnter(Collider other) {
        health -= other.GetComponent<CoinPicker>().muscle;
        Debug.Log(health);
        if (health <= 0) {
            
        }
    }
    
}
