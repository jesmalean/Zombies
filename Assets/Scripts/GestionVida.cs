using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GestionVida : MonoBehaviour
{
    public float Vida = 5f;
    public float MaxVida = 5f;
    float VidaRestante;
    public GameObject BarraVida; // Referencia al cubo
    public Color colorVerde;
    public Color colorRojo;

    public UnityEvent hesidoTocado; // Evento para cuando el objeto es tocado
    public UnityEvent estoyMuerto; // Evento para cuando el objeto muere

    void Start()
    {
        BarraVida.GetComponent<Renderer>().material.color = colorVerde; // Establecer el color inicial del cubo
    }

    void tocado(float fuerza) {
        Vida -= fuerza;
        VidaRestante = Vida / MaxVida;
        BarraVida.transform.localScale = new Vector3(VidaRestante, 0.21602f, 0.0038283f);
        BarraVida.GetComponent<Renderer>().material.color = colorRojo;
        StartCoroutine(RevertirColor());
        hesidoTocado.Invoke(); // Llamar al evento hesidoTocado
        if(Vida <= 0) {
            estoyMuerto.Invoke(); // Llamar al evento estoyMuerto si la vida es igual o menor a cero
            Destroy(gameObject);
        }
    }

    IEnumerator RevertirColor()
    {
        yield return new WaitForSeconds(1f);
        BarraVida.GetComponent<Renderer>().material.color = colorVerde;
    }
}