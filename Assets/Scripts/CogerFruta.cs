using UnityEngine;

public class CogerFruta : MonoBehaviour
{
    Animator animator;
    int estado;
    bool recogida;
    Paneles hud;
    AudioSource sonido;

    void Start()
    {
        animator = GetComponent<Animator>();
        hud = FindFirstObjectByType<Paneles>();
        sonido = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !recogida)
        {
            recogida = true;

            DatosJugador.frutas++;

            if (hud != null)
            {
                hud.ActualizarFrutas(DatosJugador.frutas);
            }

                sonido.Play();


            estado = 1;
        }

        animator.SetInteger("estado", estado);
    }

    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}