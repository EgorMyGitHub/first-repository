using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] 
    private Material changeColor;

    [SerializeField] 
    private Material[] playerColor;
    
    [Header("Canvas")]
    
    [field: SerializeField] 
    private Canvas DieScreen;
    
    private float inputSpeedH;
    
    private float inputSpeedV;

    private Rigidbody rigid;

    private int score;

    private void Awake()
    {
        DieScreen.gameObject.SetActive(false);
        
        rigid = GetComponent<Rigidbody>();

        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        changeColor.color = Color.white;
    }

    private void Update()
    {
        inputSpeedH = Input.GetAxis("Horizontal");
        inputSpeedV = Input.GetAxis("Vertical");

        rigid.velocity = new Vector3(speed * -inputSpeedV,rigid.velocity.y,speed * inputSpeedH);
    }

    public void ShowDieScreen()
    {
        DieScreen.gameObject.SetActive(true);
    }
    
    public void ChangeColor()
    {
        score++;
            
        switch (score)
        {
            case 1:
                changeColor.color = playerColor[0].color;
                break;
            case 2:
                changeColor.color = playerColor[1].color;
                break;
            case 3:
                changeColor.color = playerColor[2].color;
                break;
            case 4:
                changeColor.color = playerColor[3].color;
                break;
            case 5:
                changeColor.color = playerColor[4].color;
                break;
            case 6:
                changeColor.color = playerColor[5].color;
                break;
        }
    }
}
