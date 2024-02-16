using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_RigidBody : MonoBehaviour
{
    
    Rigidbody rb; //Almacenara el componente RigidBody del Personaje --Acceso: Privado
    Collider coll; //Componente Collider para modificar las friccion del personaje ante los diferentes terrenos

    [SerializeField] float velocidad = 10f; //Velocidad de movimiento ... Configurable desde Inspector
    [SerializeField] float fuerzaSalto = 10f; //Fuerza de salto ... Configurable desde Inspector

    [SerializeField] Transform groundCheck; //Componente para comprobar si se esta interactuando con el terreno (suelo)
    [SerializeField] LayerMask suelo_mask; //Mascara creada para determinar si el objeto con el que se esta interactuando es el Suelo

    //Utilizados para comprobar interaccion con el suelo...
    [SerializeField] float altoPersonaje = 2f; //
    [SerializeField] float area_deteccion = 0.4f;
    
    [SerializeField] bool enSuelo;
    [SerializeField] bool enPendiente;
    
    RaycastHit hitPendiente;
    private float largo_rayo_pendiente = 1.2f; //Comprueba si el personaje esta en una pendiente

    //Vectores que almacenan el movimiento del personaje...
    Vector3 v_movimiento_personaje;
    Vector3 v_movimiento_personaje_pendiente;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        coll = GetComponent<Collider>();
    }

    bool estaEnPendiente() {
        //Debug.DrawRay(groundCheck.position, Vector3.down * largo_rayo_pendiente, Color.red);
                
        if (Physics.Raycast(transform.position, Vector3.down, out hitPendiente, altoPersonaje / 2 + largo_rayo_pendiente))
        {            
            float angulo = Vector3.Angle(Vector3.up, hitPendiente.normal);
            //Debug.Log(angulo);

            if (angulo > 45)
            {
                coll.material.dynamicFriction = 0;
                coll.material.staticFriction = 0;
                rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
            }
            else {
                coll.material.dynamicFriction = 10;
                coll.material.staticFriction = 10;
            }
            
            return (hitPendiente.normal != Vector3.up);
        }
        return false;        
    }    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        v_movimiento_personaje = transform.right * horizontal + transform.forward * vertical;        

        //Opcion 1
        //Debug.DrawRay(transform.position, Vector3.down * (altoPersonaje/2+area_deteccion), Color.red);
        //enSuelo = Physics.Raycast(transform.position, Vector3.down, altoPersonaje / 2 + area_deteccion);

        //Opcion 2 - Mejorada
        enSuelo = Physics.CheckSphere(groundCheck.position,area_deteccion, suelo_mask);


        if (Input.GetButtonDown("Jump") && enSuelo) 
        {
            if (enSuelo)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }            
        }

        //ajusta drag
        if (enSuelo)
        {
            rb.drag = 6f;
        }
        else {
            rb.drag = 0f;
        }
        ////////////////////

        enPendiente = estaEnPendiente();
        v_movimiento_personaje_pendiente = Vector3.ProjectOnPlane(v_movimiento_personaje, hitPendiente.normal);
        

    }

    private void FixedUpdate()
    {
        ///////////////////////////////////////////////////////////////////////////                      
        ///Para limitar la velocidad en diagonal!   
        //v_movimiento_personaje = Vector3.ClampMagnitude(v_movimiento_personaje, 1.0f);
        ///////////////////////////////////////////////////////////////////////////
        //v_movimiento_personaje *= velocidad * 10f; //10 = constante
        //rb.AddForce(v_movimiento_personaje, ForceMode.Acceleration);

        if (enSuelo && !enPendiente)
        {
            rb.AddForce(v_movimiento_personaje.normalized * velocidad * 10f, ForceMode.Acceleration);
        }
        else if (enSuelo && enPendiente) {
            rb.AddForce(v_movimiento_personaje_pendiente.normalized * velocidad * 10f, ForceMode.Acceleration);
        }
        else if(!enSuelo){
            rb.AddForce(v_movimiento_personaje.normalized * velocidad * 10f * 0.1f, ForceMode.Acceleration);
        }
        

        // Debug.Log(v_movimiento_personaje);

    }


    #region Subir - Bajar de Plataformas

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);

        if (name.Equals("Plataforma Movil"))
        {
            rb.interpolation = RigidbodyInterpolation.None;
            transform.SetParent(collision.collider.transform);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);

        if (name.Equals("Plataforma Movil"))
        {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            transform.transform.SetParent(null);
        }
    }
    #endregion


    private void OnDrawGizmos()
    {
        //Dibuja el area de deteccion con el suelo:
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, area_deteccion);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(groundCheck.position, Vector3.down * largo_rayo_pendiente);
    }
}
