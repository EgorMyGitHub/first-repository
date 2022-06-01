using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button StartButton;

    [SerializeField] private Button ExitButton;

    [SerializeField] private Text RecordText;

    private int ScoreRecord;
    
    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
        ExitButton.onClick.AddListener(Exit);

        ScoreRecord = PlayerPrefs.GetInt("Score", ScoreRecord);

        RecordText.text = "Record - " + ScoreRecord;
    }

    private void Exit()
    {
        Application.Quit();
    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
