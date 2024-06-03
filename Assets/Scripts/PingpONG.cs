using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public Transform target;         // El objeto objetivo al que el objeto con pinchos se moverá
    public float speed = 2.0f;       // La velocidad de movimiento del objeto
    private Vector3 originalPosition; // La posición original del objeto
    private bool movingToTarget = true; // Indica si el objeto se está moviendo hacia el objetivo o de vuelta

    void Start()
    {
        // Guardar la posición original del objeto
        originalPosition = transform.position;
    }

    void Update()
    {
        // Determinar el destino actual
        Vector3 destination = movingToTarget ? target.position : originalPosition;

        // Mover el objeto hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // Comprobar si el objeto ha alcanzado el destino
        if (transform.position == destination)
        {
            // Cambiar la dirección del movimiento
            movingToTarget = !movingToTarget;
        }
    }
}
