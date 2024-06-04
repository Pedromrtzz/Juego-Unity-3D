using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoMovimiento : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;

    private Vector3 direction;
    private bool isReturning = false;

    void Start()
    {
        // Set initial position
        transform.position = startPoint.position;

        // Calculate direction to move
        direction = (endPoint.position - startPoint.position).normalized;
    }

    void Update()
    {
        // Move the log
        if (!isReturning)
        {
            transform.position += direction * speed * Time.deltaTime;

            // Check if the log has reached the end point
            if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
            {
                isReturning = true;
                direction = -direction;  // Reverse direction
            }
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;

            // Check if the log has returned to the start point
            if (Vector3.Distance(transform.position, startPoint.position) < 0.1f)
            {
                isReturning = false;
                direction = -direction;  // Reverse direction
            }
        }

        // Rotate the log to simulate rolling
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
