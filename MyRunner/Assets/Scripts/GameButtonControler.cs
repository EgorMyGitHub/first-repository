using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameButtonControler : MonoBehaviour
{
    [field: SerializeField] 
    private Button QuitButton;

    [field: SerializeField] 
    private Button RestartButton;

    [field: SerializeField] 
    private Button MenuButton;

    void Awake()
    {
        QuitButton.onClick.AddListener(Quit);
        RestartButton.onClick.AddListener(Restart);
        MenuButton.onClick.AddListener(Menu);
    }

    private void OnDestroy()
    {
        QuitButton.onClick.RemoveListener(Quit);
        RestartButton.onClick.RemoveListener(Restart);
        MenuButton.onClick.RemoveListener(Menu);
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
    private void Quit()
    {
        Application.Quit();
    }
}
