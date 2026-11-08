
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float alturaMaxima = 2f;
    public float distanciaHorizontal = 1f;
    public float velocidad = 3f;


    void Update()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject objeto in objetos)
        {
            Rigidbody2D jugador = objeto.GetComponent<Rigidbody2D>();

            float distanciaY = objeto.transform.position.y - transform.position.y;
            float distanciaX = Mathf.Abs(objeto.transform.position.x - transform.position.x);

            if (distanciaY >= 0 && distanciaY <= alturaMaxima &&
                distanciaX <= distanciaHorizontal)
            {
                if (jugador != null)
                {
                    jugador.linearVelocityY = velocidad;
                }
            }
        }
    }

}
