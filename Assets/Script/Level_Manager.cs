using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class Level_Manager : MonoBehaviour
{
    private int currentSceneIndex;

    private const int mainMenuIndex = 0;

    public Level_TextUI levelUI;

    private SoundManager soundManager;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnLevelComplete()
    {
        Debug.Log("Level Complete!");

        LoadNextLevel();
    }
  
    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if(nextSceneIndex < totalNumberOfScenes)
        {
            SceneManager.LoadScene(nextSceneIndex);
            
        }
        else
        {
            Debug.Log("You've Completed all Levels!");
        }
        if (currentSceneIndex + 1 < totalNumberOfScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
            
        }
        else
        {
            levelUI.ShowGameWinUI();
        }
        

    }
    public void OnPlayerDeath()
    {
        levelUI.ShowGameLoseUI();
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }
}
