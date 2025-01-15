using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpike : MonoBehaviour
{
    public float rotationAngle = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     private void Update()
    {
        RotateSpikeBall();
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime); // rotate around z axis
    }
}
