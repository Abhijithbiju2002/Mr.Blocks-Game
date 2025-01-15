using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed;

    private Rigidbody2D rb;

    public Level_Manager levelManager;

    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the SoundManager from the scene
        soundManager = FindObjectOfType<SoundManager>();

        if(soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }
    private void PlayerDied()
    {
        soundManager.GameOverAudio();
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        soundManager.PlayLevelComplete();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
   
}
