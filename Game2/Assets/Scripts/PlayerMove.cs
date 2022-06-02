using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] 
    private float Speed;

    [SerializeField]
    private float JumpForce;

    [SerializeField] 
    private LayerMask WhatIsGround;

    [SerializeField] 
    private float distance;

    [SerializeField] 
    private Transform feetPos;

    private bool IsGrouds;

    private float InputSpeed;

    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        InputSpeed = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(InputSpeed * Speed,rb.velocity.y);
    }

    public void Lose()
    {
        Destroy(gameObject);
        
        FindObjectOfType<RestartButton>().RestartB.gameObject.SetActive(true);
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1;
    }
    
    private void Jump()
    {
        IsGrouds = Physics2D.Raycast(feetPos.position,Vector2.down,distance,WhatIsGround);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrouds)
        {
            rb.velocity = Vector2.up * JumpForce; 
        }
    }

    private void Move()
    {
        Jump();
    }
    
    private void Update()
    {
        Move();
    }
}
