using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour {
    
    public int jumpLife = 0;
    public int muscle = 0;
    public int coin = 0;

    
    void OnTriggerEnter(Collider other) {
        if (other.tag == "jumpLife") {
            jumpLife++;
            GameObjectUtil.Destroy(other.gameObject);
        }
        if (other.tag == "muscle") {
            muscle++;
            GameObjectUtil.Destroy(other.gameObject);
        }
        if (other.tag == "coin") {
            coin++;
            GameObjectUtil.Destroy(other.gameObject);
        }
    }
}
