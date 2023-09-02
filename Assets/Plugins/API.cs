// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using SimpleJSON;
// using UnityEngine.UI;
// using TMPro;

// public class API : MonoBehaviour
// {
//     public float updateInterval = 1f; // actualización cada segundo
//     private WaitForSeconds waitInterval; // intervalo de espera

//     public JSONNode apiInfo;
//     private readonly string basePokeURL = "http://localhost:5000/index";
//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(GetAPI());
//         waitInterval = new WaitForSeconds(updateInterval);
//         StartCoroutine(CustomUpdateCoroutine());
//         Debug.Log(apiInfo["barco"]["posY"].AsInt);
//     }

//     private IEnumerator CustomUpdateCoroutine()
//     {
//         while (true)
//         {
//             StartCoroutine(GetAPI());
//             yield return waitInterval; // espera intervalo tiempo
//         }
//     } 

//     IEnumerator GetAPI() // corutina que hace request, espera respuesta y la guarda en un JSON
//     {
//         UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(basePokeURL);
       
//         yield return pokeInfoRequest.SendWebRequest();

//         if (pokeInfoRequest.result == UnityWebRequest.Result.ConnectionError || pokeInfoRequest.result == UnityWebRequest.Result.ProtocolError)
//         {
//             Debug.LogError(pokeInfoRequest.error);
//             yield break;
//         }
    
//         JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text); // guarda la respuesta en un JSON
//         apiInfo = pokeInfo;
//         // pasar lo que hay aqui a otros objetos
        

//     }
//     private string CapitalizeFirstLetter(string str)
//     {
//         return char.ToUpper(str[0]) + str.Substring(1);
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         // StartCoroutine(GetAPI()); // llama a la corutina pero era muy rapida
//         Debug.Log(apiInfo["barco"]["posY"].AsInt); // imprime el valor de la posicion en Y del barco (PRUEBA)

//     }

// }