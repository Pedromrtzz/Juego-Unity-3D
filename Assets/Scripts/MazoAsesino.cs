using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingTrap : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 45f;

    // Ángulo máximo de la oscilación
    public float maxAngle = 90f;

    // Update se llama una vez por frame
    void Update()
    {
        // Calcular la nueva rotación usando Mathf.PingPong
        float angle = Mathf.PingPong(Time.time * rotationSpeed, maxAngle * 2) - maxAngle;

        // Aplicar la rotación al objeto
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}

