using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private static Musica instance = null;
    public static Musica Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Obtén el componente AudioSource y reproduce la música
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}

