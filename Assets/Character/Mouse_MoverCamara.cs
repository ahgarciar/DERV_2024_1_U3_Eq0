using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_MoverCamara : MonoBehaviour
{
    [SerializeField]
    Transform camara;

    [SerializeField]
    float velocidad;


    [SerializeField]
    float anguloX; //el mouse se mueve sobre el eje Y, sin embargo, el objeto (camara) debe rotar sobre su eje X para subir o bajar la mira de la camara 

    // Start is called before the first frame update
    void Start()
    {
        anguloX = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        float valY = Input.GetAxis("Mouse Y");

        float valY_conVelocidad = valY * velocidad; //* Time.deltaTime //conviene? 

        //Debug.Log("Y: [" + valY + " -- "+ valY_conVelocidad+ "]");


        anguloX -= valY_conVelocidad;//invert axis
        
        anguloX = Mathf.Clamp(anguloX,-45f, 45f);
        //Debug.Log("Angulo Y: " + anguloX);

        camara.localRotation = Quaternion.Euler(anguloX, 0f, 0f);

    }
}
