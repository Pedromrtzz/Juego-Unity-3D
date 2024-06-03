using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    // Método llamado cuando el jugador colisiona con el objeto "letal"
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("ObjetoLetal"))
        {
            if (transform.parent != null)
            {
                Debug.Log("ObjetoLetal detectado. Desactivando el GameObject padre: " + transform.parent.gameObject.name);
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("ObjetoLetal detectado. Desactivando el GameObject: " + gameObject.name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("El objeto colisionado no tiene la etiqueta 'ObjetoLetal'.");
        }
    }
}
