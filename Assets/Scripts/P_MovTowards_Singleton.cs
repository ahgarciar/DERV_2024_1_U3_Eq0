using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_MovTowards_Singleton : MonoBehaviour
{
    GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
        if(SingletonDatosJuego.Instancia.isPlayerInEnemyArea){
            if (SingletonDatosJuego.Instancia.distance_enemy_to_player>2.0f){
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    personaje.transform.position,
                    Time.deltaTime * 2f);
            }
        }
    }
}
