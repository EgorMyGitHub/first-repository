using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Player m_Player;
    
    private Transform player;

    private void Awake()
    {
        m_Player = FindObjectOfType<Player>();
    }
    void Update()
    {
        player = m_Player.transform;
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
