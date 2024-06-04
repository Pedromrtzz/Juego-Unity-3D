using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Este m?todo ser? llamado cuando el jugador presione el bot?n "Play"
    public void PlayGame()
    {
        // Reemplaza "GameScene" con el nombre de tu escena del juego
        SceneManager.LoadScene("Level1");
    }

    // M?todo opcional para salir del juego
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
