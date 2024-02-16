using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_Distance : MonoBehaviour
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
        Debug.Log(getDistance());
    }

    public float getDistance(){
        float distance = Vector3.Distance(personaje.transform.position,
        enemigo.transform.position);
        return distance;        
    }
}
