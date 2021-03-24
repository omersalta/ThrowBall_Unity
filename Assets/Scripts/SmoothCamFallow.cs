using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothCamFallow : MonoBehaviour {
    
    public Vector3 fallowOffset;
    public Vector3 exitDoorPos;
    public GameObject target;
    
    public float fallowSpeed = 0.125f;
    float level = 0;
    
    
    private GameManager manager;
    private GameObject PlayerSpawnPlace;
    
    private void Awake() {
        manager = GetComponent<GameManager>();
        PlayerSpawnPlace = GameObject.Find("PlayerSpawnPlace");
        exitDoorPos = GameObject.Find("ExitDoor").GetComponent<Transform>().position;
    }

    void resetCamera() {
        transform.position = new Vector3(0, 0, -300);
    }
    
    private void Update() { 
        if (!manager.gameStarted) {
            level = 0;
        }else {
            Debug.Log("target = player adress");
            target = manager.playerAddress;
        }
    }

    // Update is called once per frame
    void LateUpdate() {
        if (!target || !target.activeSelf) {
            target = PlayerSpawnPlace;
            level = 0;
            Debug.Log("target = PlayerSpawnPlace");
        }
        
        Vector3 desiredPos = target.transform.position + fallowOffset;
        if (desiredPos.y > exitDoorPos.y) {
            desiredPos = exitDoorPos  + new Vector3(0,40,-370);
            
        }
            
        Vector3 smootedPos = Vector3.Lerp(transform.position, desiredPos, fallowSpeed);
        smootedPos.x = 0;
        if (smootedPos.y > level | !manager.gameStarted) {
            transform.position = smootedPos;
            level = smootedPos.y;
        }
    }
}
