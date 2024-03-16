using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 8.0f;
    public float valorHerida = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.forward * movDistancia);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiono");
        other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver);
        
        if(other.gameObject.tag == "Enemigo")
        {
            //Destroy(other.gameObject); //Enemigo 
            Destroy(gameObject); //Bala se destruye
        }
    }
}
