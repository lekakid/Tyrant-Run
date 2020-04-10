using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    Animator animator;
    Text txtScore;

    bool isBlink;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        txtScore = GetComponent<Text>();
    }

    public void SetScore(float Score) {
        if(isBlink)
            return;

        txtScore.text = string.Format("{0:00000}", Score);
    }

    public void Blink() {
        if(isBlink)
            return;

        isBlink = true;
        animator.SetBool("Blink", true);
        GameManager.Instance.SoundManager.Play("score");
    }

    public void StopBlink() {
        isBlink = false;
        animator.SetBool("Blink", false);
    }
}
