using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] 
    private Button StartButton;
    
    void Awake()
    {
        StartButton.onClick.AddListener(start);
    }

    private void start()
    {
        SceneManager.LoadScene("Game");
    }
}
