// Equipo #8 Reto Entrega 2

// Modelación de sistemas multiagentes con gráficas computacionales (Gpo 101)

// Ma. Raquel Landa Cavazos
// Luis Andrés Castillo Hernández

// Paulina Covarrubias Sánchez - A01383351
// Santiago Posada Sánchez Cobiza - A01383419
// Sebastián Ramírez Cordero - A01571087
// Saúl Sánchez Rangel - A01383954


// 22 de agosto del 2023

// ShipController.cs
// Este script controla el movimiento del barco y la condición de espera
// asi como la creación de los contenedores (instancias de prefabs de barcos y de contenedores).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public static ShipController Instance { get; private set; }
    public GameObject shipPrefab;    // Prefab del barco
    public GameObject containerPrefab; // Prefab del contenedor
    public Transform dockPosition;   // Posición de anclaje del barco
    public Transform finalPosition;  // Posición final después de cumplir la condición
    public int numContainers;       // Número de contenedores
    public int numRows = 3;         // Número de filas de contenedores
    public int numColumns = 4;     // Número de columnas de contenedores
    public float rowSpacing = 2f;   // Espaciado entre filas
    public float columnSpacing = 11f; // Espaciado entre columnas;
    public float shipSpeed = 15f;     // Velocidad de movimiento del barco
    public float containerSpeed = 15f; // Velocidad de los contenedores
    private GameObject currentShip;  // Referencia al barco actual
    private bool conditionMet = false; // Condición placeholder

    private void Start()
    {
        SpawnShip();
        SpawnContainers();
    }

    private void Update()
    {
        if (currentShip != null)
        {
            Vector3 target = conditionMet ? finalPosition.position : dockPosition.position; // Si la condición se cumple, el barco se mueve a la posición final, si no, se mueve a la posición de anclaje
            float distanceToTarget = Vector3.Distance(currentShip.transform.position, target); // Distancia entre el barco y el objetivo

            // Si la distancia es menor a 0.1, se cumple la condición
            if (distanceToTarget < 0.1f)
            {
                if (!conditionMet)
                    StartCoroutine(WaitForCondition()); // Espera a que se cumpla la condición
                else
                {
                    Destroy(currentShip);
                    conditionMet = false; // Resetea la condición
                }
            }
            else
            {
                currentShip.transform.position = Vector3.MoveTowards(currentShip.transform.position, target, Time.deltaTime * shipSpeed); // Mueve el barco hacia el objetivo
            }

        } // Si el barco no existe, lo instancia
    }

    private IEnumerator WaitForCondition()
    {
        yield return new WaitForSeconds(30f); // Espera 3 segundos (simulando la condición, PLACEHOLDER)
        conditionMet = true;
    }

    private void SpawnShip()
    {
        currentShip = Instantiate(shipPrefab, transform.position, Quaternion.identity); // Instancia el barco
    }

    private void SpawnContainers()
    {
        Vector3 shipDeckPosition = currentShip.transform.Find("Deck").position; // Posición de la cubierta del barco
        int containerIndex = 0;

        for (int i = 0; i < numContainers; i++)
        {
            int row = i / numColumns; // Calculate row index
            int col = i % numColumns; // Calculate column index

            float xOffset = col * columnSpacing;
            float yOffset = row * rowSpacing;
            Vector3 spawnPosition = shipDeckPosition + new Vector3(xOffset, 0, yOffset);
            GameObject container = Instantiate(containerPrefab, spawnPosition, Quaternion.identity);

            container.transform.Rotate(Vector3.up, 90.0f);
            container.transform.parent = currentShip.transform;

            containerIndex++;
            if (containerIndex >= numContainers)
            {
                break; // Break the loop if the desired number of containers is reached
            }
        }
    }
}
