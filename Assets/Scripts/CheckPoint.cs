using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardar la posición del checkpoint en el GameManager
            GameManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint alcanzado en: " + transform.position);
        }
    }
}


