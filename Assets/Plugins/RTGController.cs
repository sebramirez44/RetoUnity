// Equipo #8 Reto Entrega 2

// Modelación de sistemas multiagentes con gráficas computacionales (Gpo 101)

// Ma. Raquel Landa Cavazos
// Luis Andrés Castillo Hernández

// Paulina Covarrubias Sánchez - A01383351
// Santiago Posada Sánchez Cobiza - A01383419
// Sebastián Ramírez Cordero - A01571087
// Saúl Sánchez Rangel - A01383954


// 22 de agosto del 2023

// RTGController.cs
// Este script controla el movimiento de la grua RTG y la condición de espera (placeholder)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTGController : MonoBehaviour {

    public float speed = 5.0f;
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 1.05f;

    void Start() {
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update() {
        // voltear hacia el waypoint actual y moverse hacia él
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        transform.LookAt(targetWaypoint.position);

        // checar si se ha llegado al último waypoint
        if (targetWaypointIndex == waypoints.Count - 1 && Vector3.Distance(transform.position, targetWaypoint.position) < minDistance)
        {
            // reiniar al primer waypoint
            targetWaypointIndex = 0;
        }
        else if (Vector3.Distance(transform.position, targetWaypoint.position) < minDistance)
        {
            // moverse al siguiente waypoint
            targetWaypointIndex++;
            targetWaypoint = waypoints[targetWaypointIndex];
        }
    }
}