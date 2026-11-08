
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionDificultad : MonoBehaviour
{
    public void Facil()
    {
        DatosJugador.vidasIniciales = 5;
        IniciarPartida();
    }

    public void Normal()
    {
        DatosJugador.vidasIniciales = 3;
        IniciarPartida();
    }

    public void Dificil()
    {
        DatosJugador.vidasIniciales = 1;
        IniciarPartida();
    }

    void IniciarPartida()
    {
        DatosJugador.vidasActuales = DatosJugador.vidasIniciales;
        DatosJugador.frutas = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
