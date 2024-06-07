using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameOnCollision : MonoBehaviour
{
    public string targetTag = "Player";  // Tag del objeto que terminará el juego al colisionar

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("El objeto tocó el objetivo. Fin del juego.");

        // Para detener el juego en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Para terminar el juego en una build
        Application.Quit();
#endif
    }
}

