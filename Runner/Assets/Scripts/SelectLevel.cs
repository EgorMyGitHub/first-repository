using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SelectLevel : MonoBehaviour
{
    [field: SerializeField] 
    private TMP_Text Text;

    [field: SerializeField] 
    private Button DownButton;
    
    [field: SerializeField] 
    private Button UpButton;

    [field: SerializeField] 
    private Button Start;

    private int Level;

    private void Awake()
    {
        Level = Int32.Parse(Text.text);
        
        UpButton.onClick.AddListener(UpLevel);
        DownButton.onClick.AddListener(DownLevel);
        Start.onClick.AddListener(StartLevel);
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(Level + 1);
    }

    private void Examination()
    {
        if (Level < 1)
        {
            Text.text = "5";
            Level = 5;
        }
        if (Level > 5)
        {
            Text.text = "1";
            Level = 1;
        }
    }
    
    private void UpLevel()
    {
        Level++;

        Examination();
        
        Text.text = Level.ToString();
    }

    private void DownLevel()
    {
        Level--;

        Examination();
        
        Text.text = Level.ToString();
    }
}
