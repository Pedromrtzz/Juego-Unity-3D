using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    // Referencia al personaje
    public Transform player;

    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 2f;

    // Ángulo máximo de la inclinación
    public float maxAngle = 45f;

    // Variable para saber si el jugador está sobre la plataforma
    private bool playerOnPlatform = false;

    void Update()
    {
        if (playerOnPlatform)
        {
            // Calcular la posición relativa del jugador respecto a la plataforma
            float relativePosition = player.position.x - transform.position.x;

            // Determinar la dirección de inclinación en función de la posición relativa del jugador
            float targetAngle = Mathf.Clamp(relativePosition / (transform.localScale.x / 2) * maxAngle, -maxAngle, maxAngle);

            // Invertir el ángulo si el jugador está a la izquierda de la plataforma
            if (relativePosition < 0)
            {
                targetAngle *= -1f;
            }

            // Interpolación suave hacia el ángulo objetivo
            float currentAngle = Mathf.LerpAngle(transform.localRotation.eulerAngles.x, targetAngle, Time.deltaTime * rotationSpeed);

            // Aplicar la rotación a la plataforma
            transform.localRotation = Quaternion.Euler(currentAngle, 0, 0);
        }
        else
        {
            // Mantener la plataforma en la posición inicial (0, 0, 0) cuando el jugador no está sobre ella
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Detectar cuando el jugador entra en la plataforma
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == player)
        {
            playerOnPlatform = true;
        }
    }

    // Detectar cuando el jugador sale de la plataforma
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform == player)
        {
            playerOnPlatform = false;
        }
    }
}
