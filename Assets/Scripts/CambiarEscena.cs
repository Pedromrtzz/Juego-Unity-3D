using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Level1.unity");
    }
}