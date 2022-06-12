using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Player p;
    
    private void Start()
    {
        p.RestartButton.onClick.AddListener(Restart);
        p.MenuButton.onClick.AddListener(MenuLoad);
    }

    private void OnDestroy()
    {
        p.RestartButton.onClick.RemoveListener(Restart);
        p.MenuButton.onClick.RemoveListener(MenuLoad);
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
