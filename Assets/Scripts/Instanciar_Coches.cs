using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciar_Coches : MonoBehaviour
{
    public GameObject PrefabCoche;
    public int Cant_instancias;
    GameObject[] agents;

    // Start is called before the first frame update
    void Start()
    {
        Cant_instancias = 10;
        agents = new GameObject[Cant_instancias];

        for (int i = 0; i < Cant_instancias; i++){
            float x = i * 40 + Random.Range(-10,10);
            float y = 8.50f;
            float z = i * 40 + Random.Range(-30,30);
            if (i%2 == 1){
                agents[i] = Instantiate(PrefabCoche, new Vector3(x,y,z), Quaternion.Euler(0,250,0));
            } else{
                agents[i] = Instantiate(PrefabCoche, new Vector3(x,y,z), Quaternion.Euler(0,100,0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
