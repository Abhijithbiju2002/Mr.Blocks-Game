using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private const int firstLevel = 1;

    private SoundManager soundManager;

    // Start is called before the first frame update
    
    // Update is called once per frame
  
    private void Awake()
    {
        AddListener();

        soundManager = FindObjectOfType<SoundManager>();

    }
    private void AddListener()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }
    public void Play()
    {
        soundManager.PlayButtonClickAudio();//audio button click
        SceneManager.LoadScene(firstLevel);  // Load the first level
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();//audio button click
        Application.Quit();  // Quit the game
        Debug.Log("Game quit"); // Unity doesn't quit in the editor, so we log it
    }
}
