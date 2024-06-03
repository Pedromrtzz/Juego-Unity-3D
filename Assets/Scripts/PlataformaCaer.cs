using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1.0f;    // Tiempo de espera antes de que la plataforma caiga
    public float respawnDelay = 5.0f; // Tiempo de espera antes de que la plataforma reaparezca
    private Vector3 originalPosition; // Posición original de la plataforma
    private Quaternion originalRotation; // Rotación original de la plataforma
    private Rigidbody rb;
    private bool isFalling = false;

    void Start()
    {
        // Guardar la posición y rotación originales de la plataforma
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Asegurarse de que la plataforma esté inicialmente en reposo
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que entra en contacto es el jugador
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            // Iniciar la rutina de caída
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        // Marcar como cayendo
        isFalling = true;

        // Esperar antes de caer
        yield return new WaitForSeconds(fallDelay);

        // Permitir que la plataforma caiga
        rb.isKinematic = false;
        rb.useGravity = true;

        // Esperar antes de reaparecer
        yield return new WaitForSeconds(respawnDelay);

        // Reposicionar y restaurar la plataforma
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Marcar como no cayendo
        isFalling = false;
    }
}
