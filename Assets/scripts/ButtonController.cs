using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Player p;
    
    private void Awake()
    {
        FindObjectOfType<Player>().RestartButton.onClick.AddListener(Restart);
        FindObjectOfType<Player>().MenuButton.onClick.AddListener(MenuLoad);
    }

    private void OnDestroy()
    {
        FindObjectOfType<Player>().RestartButton.onClick.RemoveListener(Restart);
        FindObjectOfType<Player>().MenuButton.onClick.RemoveListener(MenuLoad);
    }

    private void MenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }
    
    private void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
