using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Level_TextUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI leveltext;
    public int levelNumber = 1;

    public GameObject gameOverPanel;
   
    public Button restartButton;
    public Level_Manager levelManager;

    public TextMeshProUGUI gameOverText;
    

    public Button menuButton;

    private SoundManager soundManager;

    // Start is called before the first frame update
    private void Awake()
    {
        UpdtateLevelText();

        AddListeners();

        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdtateLevelText()
    {
        leveltext.text = "Level : " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)  
    {
        gameOverPanel.SetActive(isActive);
    }
   

    private void AddListeners()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
       

    }
    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();//audio button click
       
        levelManager.RestartLevel();
    }
    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();//audio button click
        soundManager.DestroySoundManager();  // Destroy the current SoundManager
        levelManager.LoadMainMenu();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);
        

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Over!";
        
        gameOverText.color = Color.red;
        HideLevelPanel();

    }
}   
