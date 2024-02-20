using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDatos : MonoBehaviour
{
    //acceso (get) publico ... modificacion (set) privado
    public static SingletonDatos Instancia {get; private set;}

    private void Awake() {
        if(Instancia != null){ //existe una instancia de la clase
            if(Instancia != this){ //la instancia que se creo es diferente a la que ya se tenia
                Destroy(gameObject); //se destruye la nueva instancia
            }
        }
        else{ //no existe una instancia aun
            Instancia = this;
            DontDestroyOnLoad(gameObject); //se asegura que no se destruya el objeto al cambiar de escenas
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
