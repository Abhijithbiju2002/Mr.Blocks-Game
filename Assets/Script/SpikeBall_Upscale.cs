using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Upscale : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float scalingFactor = 1f;
    public float currentScale;
    public float scalingSpeed = 15;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    public float scaleDelay = 2f;  // Delay between scaling up and down
    private bool isWaiting = false;  // Is the spike in a waiting state?
    private float timer = 0f;  // Tracks the waiting period

    // Start is called before the first frame update
    void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
    }

    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall();
        

        if (isWaiting)
            HandleWaiting(); // Handle waiting logic
        else
            ScaleSpikeBall();  // Scale the spike



    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void ScaleSpikeBall()
    { 
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime; // Adjust the scale
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale); // Keep the scale within boundaries

        if (currentScale >= maxScale ||  currentScale <= minScale) // If the spike reaches its limits
        {
            scalingFactor =- scalingFactor; // Reverse the scaling direction
            isWaiting = true;
        }
        ApplyCurrentScale(); 
    }
    private void ApplyCurrentScale() 
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);//Update the spike's size
    }

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if(timer >= scaleDelay) //If timer reaches the delay time
        {
            isWaiting = false; // End the waiting period
            timer = 0f;  // Reset the timer
        }
    }
}