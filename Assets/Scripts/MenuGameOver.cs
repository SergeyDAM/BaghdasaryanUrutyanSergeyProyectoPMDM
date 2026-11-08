
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public void Reintentar()
    {
        DatosJugador.vidasActuales = DatosJugador.vidasIniciales;
        DatosJugador.frutas = 0;

        Time.timeScale = 1f;

        SceneManager.LoadScene(DatosJugador.nivelReintentar);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Modo");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
