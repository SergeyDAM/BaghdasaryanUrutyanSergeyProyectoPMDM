
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    int vidas;
    Vector3 posicionInicial;

    Paneles hud;

    void Start()
    {
        vidas = DatosJugador.vidasActuales;
        posicionInicial = transform.position;

        hud = FindFirstObjectByType<Paneles>();

        if (hud != null)
        {
            hud.ActualizarVidas(vidas);
        }
    }

    public void RecibirDano()
    {
        vidas--;

        DatosJugador.vidasActuales = vidas;

        Debug.Log("Vidas restantes: " + vidas);

        if (hud != null)
        {
            hud.ActualizarVidas(vidas);
        }

        if (vidas <= 0)
        {
            GameOver();
        }
        else
        {
            transform.position = posicionInicial;
        }
    }

    void GameOver()
    {
        DatosJugador.nivelReintentar = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOver");
    }
}
