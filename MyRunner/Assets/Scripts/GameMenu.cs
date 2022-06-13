using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] 
    private Canvas GameCanvas;
    
    [field: SerializeField] 
    private Button RestartButton;

    [field: SerializeField] 
    private Button MenuButton;

    [field: SerializeField]
    private Button ContinueButton;
    
    private bool IsVisible;

    private void Awake()
    {
        IsVisible = false;
        
        GameCanvas.gameObject.SetActive(IsVisible);
        
        RestartButton.onClick.AddListener(Restart);
        MenuButton.onClick.AddListener(Menu);
        ContinueButton.onClick.AddListener(Continue);
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Menu()
    {
        SceneManager.LoadScene(0);
    }
    private void Continue()
    {
        GameCanvas.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsVisible = (IsVisible) ? false : true;
            
            GameCanvas.gameObject.SetActive(IsVisible);

            if (IsVisible)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
