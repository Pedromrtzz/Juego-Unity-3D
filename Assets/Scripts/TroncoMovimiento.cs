using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class RollingLog : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    public float delayBeforeRestart = 2.0f;  // Delay before the log reappears at the start point

    private Vector3 direction;
    private bool isMoving = true;

    void Start()
    {
        // Set initial position
        transform.position = startPoint.position;

        // Calculate direction to move
        direction = (endPoint.position - startPoint.position).normalized;
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the log
            transform.position += direction * speed * Time.deltaTime;

            // Rotate the log to simulate rolling
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // Check if the log has reached the end point
            if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
            {
                isMoving = false;
                StartCoroutine(RestartLog());
            }
        }
    }

    private IEnumerator RestartLog()
    {
        Debug.Log("Tronco alcanz? el punto final y se ocultar?.");

        // Wait for a delay before restarting
        yield return new WaitForSeconds(delayBeforeRestart);

        // Reset position to start point
        transform.position = startPoint.position;

        Debug.Log("Tronco reaparece en el punto de inicio.");

        // Start moving again
        isMoving = true;
    }
}
