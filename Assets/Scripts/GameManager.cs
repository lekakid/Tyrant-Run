using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float DinoSpeed = 10f;

    public ObstacleController CactusController;
    public GameObject GameOverArea;
    public Text ScoreView;
    public Text HighScoreView;
    
    double Score = 0;
    double HighScore = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime * 10;
        ScoreView.text = string.Format("{0:00000}", Score);
    }

    public void GameOver() {
        Time.timeScale = 0;
        if(HighScore < Score) {
            HighScoreView.text = string.Format("HI {0:00000}", Score);
            HighScore = Score;
        }
        GameOverArea.SetActive(true);
    }

    public void Restart() {
        Score = 0;
        CactusController.Init();
        GameOverArea.SetActive(false);
        Time.timeScale = 1;
    }
}
