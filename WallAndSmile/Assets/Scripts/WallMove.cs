using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, -speed);
    }
}
