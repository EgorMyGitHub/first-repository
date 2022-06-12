using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    private Button StartButton;
    
    void Awake()
    {
        StartButton.onClick.AddListener(LoadScene);
    }

    private void OnDestroy()
    {
        StartButton.onClick.RemoveListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
