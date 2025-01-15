using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;

    public AudioSource sfxAudioSource;

    public AudioClip levelCompleteSource;
    public AudioClip gameOverAudio;
    public AudioClip ButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlaybackgroundMusic();
    }

    public void PlaybackgroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null && !backgroundAudioSource.isPlaying)
        { 
             backgroundAudioSource.Play();
        }
    }
    public void PlayLevelComplete()
    {
        if (sfxAudioSource != null && levelCompleteSource != null)
        {
            sfxAudioSource.PlayOneShot(levelCompleteSource);
        }    
    } 
    public void GameOverAudio()
    {
        if(sfxAudioSource!=null && gameOverAudio != null)
        {
            sfxAudioSource.PlayOneShot(gameOverAudio);
        }
    }
    public void PlayButtonClickAudio()
    {
        if(sfxAudioSource != null && ButtonClick != null)
        {
            sfxAudioSource.PlayOneShot(ButtonClick);
        }
    }
    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
     

        
}
