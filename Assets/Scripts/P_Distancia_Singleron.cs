using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Distancia_Singleron : MonoBehaviour
{
    GameObject personaje;
    GameObject enemigo;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        enemigo = GameObject.Find("Enemigo");
    }

    // Update is called once per frame
    void Update()
    {
        getDistance();
        Debug.Log(SingletonDatosJuego.Instancia.distance_enemy_to_player);
    }

    public void getDistance(){
        float distance = Vector3.Distance(personaje.transform.position,
        enemigo.transform.position);
        
        //manda al singleton la distancia entre el jugador y el enemigo
        SingletonDatosJuego.Instancia.distance_enemy_to_player = distance;        
    }
}
