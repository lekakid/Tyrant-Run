using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float DinoDefaultSpeed = 22f;
    public float DinoSpeed = 22f;

    public Dino Dino;
    public ObstacleController ObstacleController;
    public GameObject GameOverArea;
    public ScoreView ScoreView;
    public Text HighScoreView;
    
    float Score = 0;
    float HighScore = 0;

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime * 10;
        if((int)Score != 0 && (int)Score % 100 == 0) {
            ScoreView.Blink();
        }
        ScoreView.SetScore(Score);

        if(Score > 500f) {
            ObstacleController.Unlock();
        }

        DinoSpeed = DinoDefaultSpeed + (int)((Score > 1000f ? 1000f : Score)/125f);
        float ratio = 1 - (Score > 1000f ? 1000f : Score) / 2000f;
        ObstacleController.SetInterval(ratio);
    }

    public void GameOver() {
        ScoreView.StopBlink();
        HighScoreView.enabled = true;

        if(HighScore < Score) {
            HighScoreView.text = string.Format("HI {0:00000}", Score);
            HighScore = Score;
        }
        GameOverArea.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        DinoSpeed = DinoDefaultSpeed;
        Score = 0;
        ObstacleController.Init();
        Dino.Reborn();
        GameOverArea.SetActive(false);
        Time.timeScale = 1;
    }
}
