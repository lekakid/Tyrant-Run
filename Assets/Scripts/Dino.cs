﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float DefaultSpeed = 22f;
    public float MaxSpeed = 30f;

    public float Speed {
        get {
            return _speed;
        }
        set {
            _speed = (value < MaxSpeed) ? value : MaxSpeed;
        }
    }

    Rigidbody2D rigidBody;
    Animator animator;
    CircleCollider2D normalCollider;
    CapsuleCollider2D downCollider;

    float _speed;
    bool _isJumped;
    bool _isDied;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        normalCollider = GetComponent<CircleCollider2D>();
        downCollider = GetComponent<CapsuleCollider2D>();

        _speed = DefaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > -1.05f) {
            _isJumped = true;
        }
        else {
            _isJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            Crouch();
        }
        
        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            Uncrouch();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle")) {
            animator.SetBool("isDie", true);
            _isDied = true;
            GameManager.Instance.SoundManager.Play("gameover");
            GameManager.Instance.GameOver();
        }
    }

    public void Init() {
        _speed = DefaultSpeed;
        Uncrouch();
        animator.SetBool("isDie", false);
        rigidBody.velocity = Vector2.down;
        rigidBody.gravityScale = 13;
        normalCollider.enabled = true;
        downCollider.enabled = false;

        _isDied = false;
    }

    public void Jump() {
        if(_isJumped || _isDied)
            return;

        _isJumped = true;
        rigidBody.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
        GameManager.Instance.SoundManager.Play("btn-press");
    }

    public void Crouch() {
        rigidBody.gravityScale = 25;

        if(!_isJumped) {
            normalCollider.enabled = false;
            downCollider.enabled = true;
            animator.SetBool("isCrouched", true);
        }
    }

    public void Uncrouch() {
        rigidBody.gravityScale = 13;
        normalCollider.enabled = true;
        downCollider.enabled = false;
        animator.SetBool("isCrouched", false);
    }
}
