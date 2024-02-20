using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection_Singleton : MonoBehaviour
{
   
   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Player")){
        SingletonDatosJuego.Instancia.isPlayerInEnemyArea = true;
    }
   }

   private void OnTriggerExit(Collider other) {
    if(other.gameObject.CompareTag("Player")){
        SingletonDatosJuego.Instancia.isPlayerInEnemyArea = false;
    }
   }

}
