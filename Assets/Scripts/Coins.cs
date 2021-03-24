using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    
    void Start() {
        //Debug.Log(FindObjectOfType<DestroyOffscreen>());
        FindObjectOfType<DestroyOffscreen>().DestroyCallback += OnPlayerKilled;
    }

    void OnPlayerKilled() {
        gameObject.SetActive(true);
    }
}
