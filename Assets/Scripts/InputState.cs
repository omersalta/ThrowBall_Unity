using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {
    
    public Vector3 downPos;
    public Vector3 upPos;
    public Vector3 currentPos;
    public bool throwing;
    public bool pressed;
    
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update() {
        currentPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) {
            downPos = currentPos;
            pressed = true;
            Time.timeScale = 0.05f;
        }

        if (Input.GetMouseButtonUp(0)) {
            upPos = currentPos;
            throwing = true;
            pressed = false;
            Time.timeScale = 1;
        }
    }
    
}
