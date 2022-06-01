using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] 
    public Button RestartB;

    private void Awake()
    {
        RestartB.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
