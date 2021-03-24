using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwBall : MonoBehaviour {
    
    public Rigidbody rb;
    public float forceMultiply = 8;
    public float maxValue = 100;

    private CoinPicker _playerProperty;
    private InputState _IS;

    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody>();
        _IS = GetComponent<InputState>();
        _playerProperty = GetComponent<CoinPicker>();
    }

    private void Update() {
        //Debug.Log(IS.throwing);
        if (_IS.throwing && _playerProperty.jumpLife > 0) {
            rb.velocity = Vector3.zero;
            Force();
            _playerProperty.jumpLife--;
            _IS.throwing = false;
            //Debug.Log(_playerProperty.jumpLife);
        }
        
    }
    
    // Update is called once per frame
    void Force () {
        
        float xForce = _IS.downPos.x - _IS.upPos.x;
        float yForce = _IS.downPos.y - _IS.upPos.y;
        float bigger = Mathf.Max(Math.Abs(xForce), Math.Abs(yForce));
        float scale = bigger > maxValue ? (maxValue / bigger) : 1;
        Vector3 force = Vector3.Scale(new Vector3(xForce, yForce, 0), new Vector3(scale, scale, 1));
        rb.AddForce(force*forceMultiply,ForceMode.Impulse);
        
    }
    
}
