using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaJugador : MonoBehaviour
{
    [SerializeField]
    GameObject enemigo;
    LookAt look;

    // Start is called before the first frame update
    void Start()
    {
        look = enemigo.GetComponent<LookAt>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string tagObjeto = other.gameObject.tag;
        Debug.Log("Trigger Enter con: " + tagObjeto);

        //if (tagObjeto.Equals("Player"))
        if(other.gameObject.CompareTag("Player"))
        {
            look.JugadorEnLaMira = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tagObjeto = other.gameObject.tag;
        Debug.Log("Trigger Enter con: " + tagObjeto);

        //if (tagObjeto.Equals("Player"))
        if (other.gameObject.CompareTag("Player"))
        {
            look.JugadorEnLaMira = false;
        }
    }

}
