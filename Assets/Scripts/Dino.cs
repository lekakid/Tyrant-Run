using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public GameManager Game;
    public SoundManager Sound;

    Rigidbody2D rb;
    Animator animator;
    CircleCollider2D NormalCollider;
    CapsuleCollider2D DownCollider;

    bool isJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        NormalCollider = GetComponent<CircleCollider2D>();
        DownCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > -1.05f) {
            isJumped = true;
        }
        else {
            isJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumped) {
            isJumped = true;
            rb.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
            Sound.Play("btn-press");
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            rb.gravityScale = 25;

            if(!isJumped) {
                NormalCollider.enabled = false;
                DownCollider.enabled = true;
                animator.SetBool("isDown", true);
            }
        }
        
        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            rb.gravityScale = 13;
            NormalCollider.enabled = true;
            DownCollider.enabled = false;
            animator.SetBool("isDown", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle")) {
            animator.SetBool("isDie", true);
            Sound.Play("gameover");
            Game.GameOver();
        }
    }

    public void Reborn() {
        animator.SetBool("isDie", false);
        rb.velocity = Vector2.down;
    }
}
