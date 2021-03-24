using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    
    //TODO make other scenes and crate lock system with using PlaterPrefs cookies 
    private List<Button> LevelButtons;
    private int _levelRecord;
    
    private void Awake() {
        _levelRecord = PlayerPrefs.GetInt("C_LEVEL_RECORD");
    }

    void Start() {
        for (int i = 0; i<LevelButtons.Count; i++) {

            if (i < _levelRecord)
                LevelButtons[i].interactable = true;
            else 
                LevelButtons[i].interactable = false;
            
        }
    }
    
    public void LevelSelect() {
        int selected = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(selected);
    }
    
    
}
