using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_LookAt : MonoBehaviour
{
    [SerializeField] GameObject personaje;


    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
        //--->Vector3.forward;

        Vector3 pos = personaje.transform.position; 

        //if (pos.y > 5555) {

        pos.y = transform.position.y; //cambia la pos de ref del personaje
        //por la pos de y del enemigo 

        //}

        transform.LookAt(pos);
    }
}
