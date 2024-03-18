using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 8.0f;
    public float valorHerida = 1.0f;

    public AudioClip impactSound; // Sonido de impacto

    public Vector3 posicionDestino = new Vector3(-50.0f, 0.810000002f, 55.414f);
    
    public float distanciaMaxima = 100.0f; // Define una distancia máxima que la bala puede recorrer
    private float distanciaRecorrida = 0.0f;

    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.forward * movDistancia);
        
        // Actualiza la distancia recorrida
        distanciaRecorrida += movDistancia;
        
        // Destruye la bala si alcanza la distancia máxima
        if (distanciaRecorrida >= distanciaMaxima)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiono");
        other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver);
        
        if(other.gameObject.tag == "Enemigo")
        {
            Destroy(gameObject); //Bala se destruye
            AudioSource.PlayClipAtPoint(impactSound, transform.position);
        }
    }
}
