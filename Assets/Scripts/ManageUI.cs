using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ManageUI : MonoBehaviour {

    public GameManager GM;
    public CoinPicker playerPicker;
    public Text lifeText;
    public Text strText;
    public Text coinText;
    public Text timeText;
    void Start() {
        playerPicker = FindObjectOfType<CoinPicker>();
        GM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        //Debug.Log(playerPicker.jumpLife);
    }

    // Update is called once per frame
    void Update() {
        if (GM.gameStarted && playerPicker) {
            //playerPicker = FindObjectOfType<CoinPicker>();
            lifeText.text = playerPicker.jumpLife.ToString();
            strText.text = playerPicker.muscle.ToString();
            coinText.text = playerPicker.coin.ToString();
            timeText.text = FormatTime(GM.timeElapsed);
        }
    }
    
    string FormatTime(float value) {
        TimeSpan time = TimeSpan.FromSeconds(value);
        return (time.ToString("hh':'mm':'ss"));
    }
}
