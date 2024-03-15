using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Transform salida;
    float proximoDisparo = 0f;
    float tiempoEspera = 0.3f;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        //salida = gameObject.transform.GetChild(0).transform;
        salida = gameObject.GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proximoDisparo && Input.GetMouseButtonDown(0))
        {
            proximoDisparo = Time.time + tiempoEspera;
            Debug.Log("1 disparo");
            GameObject nuevaBala = Instantiate(bala, salida.position, salida.rotation);
            
        }

    }
}
