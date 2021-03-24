using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public FINIS_DOOR FINIS_DOOR;
    public Text continueText;
    public GameObject playerPrefab;
    public GameObject playerAddress;
    public GameObject startInfoPannel;
    public float timeElapsed = 0f;
    public bool gameStarted;
    
    
    private int _finishScore;
    private float _blinkTime = 0f;
    private bool _blink;
    private GameObject _player;
    
    private int goalScore = 500;

    private void Awake() {
        playerAddress = GameObjectUtil.Instantiate(playerPrefab,
            new Vector3(1000, -400, 0));
    }

    void Start() {
        FINIS_DOOR = FindObjectOfType<FINIS_DOOR>();
        startInfoPannel.SetActive(true);
        gameStarted = false;
        //Time.timeScale = 0;
        continueText.text = "GOAL " + goalScore.ToString();
    }
    // Update is called once per frame
    private void Update() {
       
        if (!gameStarted) {
            _blinkTime++;
            if (_blinkTime % 120 == 0)
                _blink = !_blink;
            continueText.canvasRenderer.SetAlpha(_blink ? 1 : 0);
            
        }else {
            timeElapsed += Time.deltaTime/Time.timeScale;
        }
    }
    
     void ResetGame() {
         continueText.canvasRenderer.SetAlpha(0);
        Time.timeScale = 1;
        gameStarted = true;
        startInfoPannel.SetActive(false);
        playerAddress = GameObjectUtil.Instantiate(playerPrefab,
            new Vector3(0, 150, 0));
        _player = playerAddress;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        CoinPicker playerPicker = _player.GetComponent<CoinPicker>();
        playerPicker.coin = 0;
        playerPicker.jumpLife = 20;
        playerPicker.muscle = 0;
        _player.GetComponent<DestroyOffscreen>().DestroyCallback += OnPlayerKilled;
        timeElapsed = 0f;
    }


    void OnPlayerKilled() {
        startInfoPannel.SetActive(true);
        gameStarted = false;
        //TODO finish score should taken when player die and will printing screen
        //_finishScore = FINIS_DOOR.getScore();
    }
    
    
    public void StartButton() {
        ResetGame();
    }
    
    
    
}
