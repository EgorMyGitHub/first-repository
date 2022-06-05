using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float startTimeForMove;
    
    [SerializeField] 
    private float speed;

    [SerializeField] 
    private Transform targetPos;
    
    [SerializeField] 
    private Transform targetPos1;

    [SerializeField] 
    private WallSpawn wallSpawn;

    [SerializeField] 
    private GameButton Buttons;

    private bool isLeft = true;

    private float timeForMove;

    private Rigidbody2D rigid;

    private void Awake()
    {
        Time.timeScale = 1;
        
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && timeForMove <= 0)
        {
            timeForMove = startTimeForMove;
            
            Move();
            
            isLeft = (isLeft) ? false : true;
        }
        else
        {
            timeForMove -= Time.deltaTime;
        }
        
        if (transform.position != targetPos.position && !isLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos1.position, speed * Time.deltaTime);
        }
        else if (transform.position != targetPos1.position && isLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }

    private void Move()
    {
        Debug.Log("Move");
        
        if (isLeft)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos1.position, speed * Time.deltaTime);
        }
        else if(!isLeft)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<TriggerSpawnTag>(out var triger))
        {
            wallSpawn.Spawn();
        }
        else if (col.TryGetComponent<Ship>(out var ship))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
            
            Buttons.RestartButton.gameObject.SetActive(true);
        }
    }
}
