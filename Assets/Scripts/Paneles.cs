using UnityEngine;
using TMPro;

public class Paneles : MonoBehaviour
{
    [SerializeField]
    TMP_Text textoVidas;
    [SerializeField]
    TMP_Text textoFrutas;

    public void ActualizarVidas(int vidas)
    {
        textoVidas.text = "x" + vidas;
    }

    public void ActualizarFrutas(int frutas)
    {
        textoFrutas.text = "x" + frutas;
    }

    void Start()
    {
        ActualizarVidas(DatosJugador.vidasActuales);
        ActualizarFrutas(DatosJugador.frutas);
    }
}