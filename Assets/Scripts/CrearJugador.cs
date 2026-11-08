using UnityEngine;

public class CrearJugador : MonoBehaviour
{
    void Start()
    {
        DatosJugador.vidasActuales = DatosJugador.vidasIniciales;

        Instantiate(
            DatosJugador.personajeSeleccionado,
            transform.position,
            transform.rotation
        );
    }
}
