using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_RotarPersonaje : MonoBehaviour
{

    [SerializeField]
    float velocidad;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float valX = Input.GetAxis("Mouse X");

        float valX_conVelocidad = valX * velocidad; // * Time.deltaTime; //conviene? 

        //Debug.Log("X: [" + valX + " -- "+ valX_conVelocidad+ "]");

        //alternativa -> Vector3.up
        transform.Rotate(new Vector3(0, valX_conVelocidad, 0));

    }
}
