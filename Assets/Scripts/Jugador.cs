using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    Transform salida;
    float proximoDisparo = 0f;
    float tiempoEspera = 0.3f;
    public GameObject bala;
    float MVidaJugador = 3.0f;
    float VidaJugador = 3.0f;
    public Text textoVida;
    bool invulnerable = false;
    float duracionInvulnerabilidad = 1.0f;

    public AudioClip impactSound; // Sonido de impacto

    void Start()
    {
        salida = gameObject.GetComponentInChildren<Transform>();
        ActualizarTextoVida();
    }

    void Update()
    {
        if (Time.time >= proximoDisparo && Input.GetMouseButtonDown(0))
        {
            proximoDisparo = Time.time + tiempoEspera;
            Debug.Log("1 disparo");
            GameObject nuevaBala = Instantiate(bala, salida.position, salida.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            if (!invulnerable)
            {
                AudioSource.PlayClipAtPoint(impactSound, transform.position);
                VidaJugador -= 1.0f;
                ActualizarTextoVida();
                invulnerable = true;
                StartCoroutine(DesactivarInvulnerabilidad());
            }
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Nivel2");
        }

        if (other.CompareTag("Finish2"))
        {
            SceneManager.LoadScene("Fin");
        }
    }

    IEnumerator DesactivarInvulnerabilidad()
    {
        yield return new WaitForSeconds(duracionInvulnerabilidad);
        invulnerable = false;
    }

    // Método para actualizar el texto de la vida
    void ActualizarTextoVida()
    {
        textoVida.text = "Vidas: " + VidaJugador.ToString();
        if (VidaJugador <= 0)
        {
            textoVida.text = "¡Jugador Muerto!";
            SceneManager.LoadScene("Muerte");
        }
    }
}
