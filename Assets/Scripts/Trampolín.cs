using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10.0f; // Fuerza de impulso hacia arriba

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que entra en contacto es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            // Si el jugador tiene un Rigidbody, aplicar una fuerza hacia arriba
            if (playerRb != null)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); // Resetear velocidad vertical
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}

