using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KnifeMove : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    
    [SerializeField] 
    private Transform target;
    
    [SerializeField] 
    private Transform target1;
    
    private bool IsDown = false;

    private float startTimer;
    
    private float timer;

    private void Awake()
    {
        startTimer = Random.Range(0f, 5f);
    }

    void Update()
    {
        if (timer >= startTimer)
        {
            if (IsDown)
            {
                transform.position = Vector3.MoveTowards(transform.position,target1.position,speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            }

            if (transform.position == target.position || transform.position == target1.position)
            {
                IsDown = (IsDown) ? false : true;
            }
        }
        else
        {
            timer++;
        }
    }
}
