using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePatrolling : MonoBehaviour
{
    public float rotationAngle = 90f;
    float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;


    // Start is called before the first frame update
    void Start()
    {
        SetPatrolPoints(); 
    }

    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall(); // Keep rotating the spike
        PatrolSpikeBall();  // Move the spike between points
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }
    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if(transform.position == targetPoint)
        {
            targetPoint =(targetPoint == pointA) ? pointB : pointA;
        }
    }
}
