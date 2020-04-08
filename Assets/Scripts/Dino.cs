using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public GameManager Manager;

    Rigidbody2D rb;
    bool isJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumped) {
            isJumped = true;
            rb.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            rb.gravityScale = 25;
        }
        
        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            rb.gravityScale = 13;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Floor")) {
            isJumped = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Cactus")) {
            Manager.GameOver();
        }
    }
}
