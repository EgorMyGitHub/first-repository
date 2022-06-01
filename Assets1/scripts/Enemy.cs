using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float speed;
    
    void Update()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
