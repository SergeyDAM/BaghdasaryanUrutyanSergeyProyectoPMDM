using UnityEngine;
using UnityEngine.UI;

public class SeleccionPersonaje : MonoBehaviour
{
    [SerializeField]
    GameObject[] personajes;

    [SerializeField]
    Sprite[] retratos;

    [SerializeField]
    Image[] imagenesHuecos;

    int indiceInicial = 0;
    int indiceSeleccionado = -1;

    void Start()
    {
        ActualizarHuecos();
        if (DatosJugador.personajeSeleccionado == null)
        {
            SeleccionarHueco(indiceInicial);
        }
    }

    public void Seleccionar(int numero)
    {
        DatosJugador.personajeSeleccionado = personajes[numero];
    }

    public void Siguiente()
    {
        indiceInicial = (indiceInicial + 1) % personajes.Length;
        indiceSeleccionado = -1;

        ActualizarHuecos();
    }

    public void Anterior()
    {
        indiceInicial = (indiceInicial - 1 + personajes.Length)
                        % personajes.Length;

        indiceSeleccionado = -1;

        ActualizarHuecos();
    }

    public void SeleccionarHueco(int posicion)
    {
        indiceSeleccionado = (indiceInicial + posicion) % personajes.Length;

        Seleccionar(indiceSeleccionado);

        ActualizarHuecos();
    }

    void ActualizarHuecos()
    {
        for (int i = 0; i < imagenesHuecos.Length; i++)
        {
            int numero = (indiceInicial + i) % personajes.Length;

            imagenesHuecos[i].sprite = retratos[numero];

            if (numero == indiceSeleccionado)
            {
                imagenesHuecos[i].color = new Color(1f, 0.75f, 0.2f, 1f);
            }
            else
            {
                imagenesHuecos[i].color = Color.white;
            }
        }
    }
}