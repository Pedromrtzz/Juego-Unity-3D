using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 45f;

    // Start se llama antes de la primera actualización del frame
    void Start()
    {

    }

    // Update se llama una vez por frame
    void Update()
    {
        // Calcular la cantidad de rotación para este frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Aplicar la rotación al objeto
        transform.Rotate(0, rotationAmount, 0);
    }
}

