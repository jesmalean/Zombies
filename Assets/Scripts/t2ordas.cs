using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t2ordas : MonoBehaviour
{
    public valoresenemigos[] valoresEnemigos;
    public valoresenemigos enemigoActual;
    public Transform jugador; // Referencia al jugador
    public float radioInstanciacion = 5f; // Radio de instanciación alrededor del jugador
    public float tiempoEsperaInicio = 2f; // Tiempo de espera al inicio antes de crear enemigos
    float tiempoEspera = 0;
    int numOrdaActual = 0;
    int enemigosporCrear = 0;
    int enemigosporMatar = 0;
    bool esperaTerminada = false; // Indica si la espera inicial ha terminado
    
    void Start()
    {
        LivingEntity.onDeathAnother += EnemigoMuerto;
        StartCoroutine(EsperarInicio());
    }

    IEnumerator EsperarInicio()
    {
        yield return new WaitForSeconds(tiempoEsperaInicio);
        esperaTerminada = true;
        NextOrda();
    }

    void NextOrda()
    {
        numOrdaActual++;
        enemigoActual = valoresEnemigos[numOrdaActual - 1];
        enemigosporCrear = enemigoActual.numeroEnemigos;
        enemigosporMatar = enemigoActual.numeroEnemigos;
    }

    void EnemigoMuerto()
    {
        enemigosporMatar--;
        if (enemigosporMatar <= 0)
        {
            NextOrda();
        }
    }

    void Update()
    {
        if (esperaTerminada && enemigosporCrear > 0 && tiempoEspera <= 0)
        {
            // Calcular una posición aleatoria dentro del radio alrededor del jugador
            Vector3 posicionInstancia = Random.insideUnitSphere * radioInstanciacion + jugador.position;
            // Asegurarse de que la posición no esté debajo del suelo
            posicionInstancia.y = Mathf.Max(posicionInstancia.y, 0f);
            // Instanciar el enemigo en la posición calculada
            Instantiate(enemigoActual.tipoEnemigo, posicionInstancia, Quaternion.identity);
            enemigosporCrear--;
            tiempoEspera = enemigoActual.tiempoEntreEnemigos;
        }
        else
        {
            tiempoEspera -= Time.deltaTime;
        }
    }
}
