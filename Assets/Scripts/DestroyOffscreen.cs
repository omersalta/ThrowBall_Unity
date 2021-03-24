using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public float offset = 50f;
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;

    private bool _offscreen;
    private float _offscreenY = 0;
    
    // Update is called once per frame
    void Update () {
        
        var posY = transform.position.y + offset;
        _offscreenY = Camera.main.transform.position.y - Screen.height/2;
        
        if (posY < _offscreenY) {
            _offscreen = true;
        } else {
            _offscreen = false;
        }
        
        if (_offscreen) {
            OnOutOfBounds();
        }

    }

    public void OnOutOfBounds(){
        _offscreen = false;
        if (DestroyCallback != null) //if player destroy;
        {   
            DestroyCallback();
        }
        GameObjectUtil.Destroy(gameObject);
    }
    
}