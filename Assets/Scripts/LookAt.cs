using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public bool JugadorEnLaMira;

    //Mirar a = look at
    [SerializeField] Transform obj_a_Mirar;

    // Start is called before the first frame update
    void Start()
    {
        JugadorEnLaMira = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (JugadorEnLaMira)
        {
            //transform se refiere al componente Transform del objeto que tiene al script
            transform.LookAt(obj_a_Mirar);
        }
    }
}
