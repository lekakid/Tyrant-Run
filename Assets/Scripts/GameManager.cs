using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Inspector
    [Header("Object")]
    public Dino Dino;
    public ObstacleController ObstacleController;

    [Header("View")]
    public GameObject GameOverArea;
    public ScoreView ScoreView;
    public Text HighScoreView;
    public GameObject TouchArea;
    public GameObject LetterBox;
    #endregion

    #region Property
    public static GameManager Instance {
        get {
            return _instance;
        }
    }
    public SoundManager SoundManager {
        get {
            return _soundManager;
        }
    }
    #endregion

    #region MemberVariable
    static GameManager _instance = null;
    SoundManager _soundManager;

    float _score = 0;
    float _highScore = 0;
    #endregion

    void Awake()
    {
        if(_instance == null) {
            _instance = this;
        }

        _soundManager = GetComponent<SoundManager>();

        switch(Application.platform) {
            case RuntimePlatform.Android:
                LetterBox.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
            
        _score += Time.deltaTime * 10;

        if(_score > 500f) {
            ObstacleController.Unlock();
        }

        if((int)_score != 0 && (int)_score % 125f == 0) {
            Dino.Speed = Dino.DefaultSpeed + _score / 125f;
        }

        float ratio = 1 - (_score > 1000f ? 1000f : _score) / 2000f;
        ObstacleController.SetInterval(ratio);

        if((int)_score != 0 && (int)_score % 100f == 0) {
            ScoreView.Blink();
        }
        ScoreView.SetScore(_score);
    }

    public void GameOver() {
        ScoreView.StopBlink();
        HighScoreView.enabled = true;

        if(_highScore < _score) {
            _highScore = _score;
            HighScoreView.text = string.Format("HI {0:00000}", _score);
        }
        GameOverArea.SetActive(true);
        TouchArea.SetActive(false);
        Time.timeScale = 0;
    }

    public void Restart() {
        _score = 0;
        ObstacleController.Init();
        Dino.Init();
        GameOverArea.SetActive(false);
        TouchArea.SetActive(true);
        Time.timeScale = 1;
    }
}
