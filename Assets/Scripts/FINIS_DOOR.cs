using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINIS_DOOR : MonoBehaviour {
    
    private CoinPicker playerPicker;
    private int _jumpLifeCount; //when player reach finih door, how many he has life
    void OnTriggerEnter(Collider other) {
        playerPicker = other.gameObject.GetComponent<CoinPicker>();
        _jumpLifeCount = playerPicker.jumpLife;
    }

    public int getScore() {
        return (playerPicker.coin * playerPicker.muscle) + (15 * _jumpLifeCount);
    }

}
