using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    Animator animator;
    Text TextScore;

    bool isBlink;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        TextScore = GetComponent<Text>();
    }

    public void SetScore(float Score) {
        if(isBlink)
            return;

        TextScore.text = string.Format("{0:00000}", Score);
    }

    public void Blink() {
        isBlink = true;
        animator.SetBool("Blink", true);
    }

    public void StopBlink() {
        isBlink = false;
        animator.SetBool("Blink", false);
    }
}
