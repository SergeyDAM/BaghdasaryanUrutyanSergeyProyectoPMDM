using UnityEngine;

public class Trampolin : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("estado",1);
            MovimientoChat jugador = collision.gameObject.GetComponent<MovimientoChat>();
            Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                jugador.RecuperarControl();
                rb2d.linearVelocityY = 12f;
            }
        }
    }

    void TerminarSalto()
    {
        animator.SetInteger("estado", 0);
    }
}
