// Equipo #8 Reto Entrega 2

// Modelación de sistemas multiagentes con gráficas computacionales (Gpo 101)

// Ma. Raquel Landa Cavazos
// Luis Andrés Castillo Hernández

// Paulina Covarrubias Sánchez - A01383351
// Santiago Posada Sánchez Cobiza - A01383419
// Sebastián Ramírez Cordero - A01571087
// Saúl Sánchez Rangel - A01383954


// 22 de agosto del 2023

// createMesh.cs
// Este script crea un mesh de un cubo, que simula un contenedor.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class createMesh : MonoBehaviour {

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    public Material meshMaterial;


    void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GameObject meshObject = new GameObject("ContenedorChico");
        MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();
        meshFilter.mesh = mesh;
        
        meshRenderer.material = meshMaterial;
        meshObject.transform.position = new Vector3(-3f, 15f, -64f);
    }

    void CreateShape() {
        Vector3 vertex0 = new Vector3(0, 0, 0);
        Vector3 vertex1 = new Vector3(1, 0, 0);
        Vector3 vertex2 = new Vector3(1, 1, 0);
        Vector3 vertex3 = new Vector3(0, 1, 0);
        Vector3 vertex4 = new Vector3(0, 0, 1);
        Vector3 vertex5 = new Vector3(1, 0, 1);
        Vector3 vertex6 = new Vector3(1, 1, 1);
        Vector3 vertex7 = new Vector3(0, 1, 1);
        
        vertices = new Vector3[] {
            vertex0, vertex1, vertex2, vertex3, vertex4, vertex5, vertex6, vertex7
        };

        triangles = new int[] {
            0, 2, 1, 0, 3, 2,
            4, 5, 6, 4, 6, 7,
            0, 1, 5, 0, 5, 4,
            2, 3, 7, 2, 7, 6,
            0, 4, 7, 0, 7, 3,
            1, 2, 6, 1, 6, 5
        };
    }

    void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}