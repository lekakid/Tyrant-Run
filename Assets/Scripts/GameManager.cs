using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float DinoSpeed = 10f;

    public CactusController CactusController;
    public GameObject GameOverArea;
    
    int Score = 0;
    int HighScore = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        Time.timeScale = 0;
        GameOverArea.SetActive(true);
    }

    public void Restart() {
        Score = 0;
        CactusController.Init();
        GameOverArea.SetActive(false);
        Time.timeScale = 1;
    }
}
