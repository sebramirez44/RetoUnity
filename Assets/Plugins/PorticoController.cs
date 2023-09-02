// Equipo #8 Reto Entrega 2

// Modelación de sistemas multiagentes con gráficas computacionales (Gpo 101)

// Ma. Raquel Landa Cavazos
// Luis Andrés Castillo Hernández

// Paulina Covarrubias Sánchez - A01383351
// Santiago Posada Sánchez Cobiza - A01383419
// Sebastián Ramírez Cordero - A01571087
// Saúl Sánchez Rangel - A01383954


// 22 de agosto del 2023

// PorticoController.cs
// Este script controla el movimiento de la grua portico y la condición de espera (placeholder)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorticoController : MonoBehaviour
{
    public Transform waypointD; // Waypoint destino
    public Transform waypointE; // Waypoint 
    public float moveSpeed = 5.0f;
    public GameObject cabina; // cabina de la grua
    private bool hasContainer = false; // flag para saber si la grua tiene un contenedor
    private GameObject currentContainer; // contenedor actual
    private float pickupDelay = 12.0f;
    private float pickupTimer = 0.0f;
    private GameObject Ship; // 
    public Transform waypointShip; 
    public GameObject newCabinaPrefab; // Prefab de la nueva cabina (para la animacion)
    private GameObject newCabina; // Referencia a la nueva cabina

    private void Start()
    {
        Ship = GameObject.FindGameObjectWithTag("Ship");
    }

    private void Update()
    {
        if (Ship != null)
        {
            // Verifica si ha llegado al waypoint (usando una comparación de distancia)
            if (Vector3.Distance(Ship.transform.position, waypointShip.position) < 1f)
            {
                // Mueve el objeto hacia el waypoint
                if (cabina != null)
                {
                    cabina.transform.position = Vector3.MoveTowards(cabina.transform.position, waypointD.position, moveSpeed * Time.deltaTime);
                }
            }
        }

        if (!hasContainer)
        {
            pickupTimer += Time.deltaTime;
            if (pickupTimer >= pickupDelay)
            {
                PickUpContainer();
            }
        }

        if (hasContainer)
        {
            if (newCabina != null)
            {
                Vector3 target = waypointE.position;
                newCabina.transform.position = Vector3.MoveTowards(newCabina.transform.position, target, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void PickUpContainer()
    {
        hasContainer = true;
        pickupTimer = 0.0f;

        GameObject[] containersOnShip = GameObject.FindGameObjectsWithTag("Container");

        if (containersOnShip.Length > 0)
        {
            for (int i = 0; i < 4; i++) {
                Destroy(containersOnShip[i]);
            }
           
            if (newCabinaPrefab != null)
            {
                newCabina = Instantiate(newCabinaPrefab, cabina.transform.position, cabina.transform.rotation);
                cabina.SetActive(false); // Deactivate the old crane arm
                newCabina.transform.position = Vector3.MoveTowards(newCabina.transform.position, waypointE.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}