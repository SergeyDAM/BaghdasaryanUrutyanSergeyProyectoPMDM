using System.Collections;
using UnityEngine;

public class BloquePincho : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Guiñar());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 contacto = collision.GetContact(0).point;
            Vector2 centro = transform.position;

            float diferenciaX = contacto.x - centro.x;
            float diferenciaY = contacto.y - centro.y;

            if (Mathf.Abs(diferenciaX) > Mathf.Abs(diferenciaY))
            {
                if (diferenciaX < 0)
                    animator.SetInteger("estado", 2); // Izquierda
                else
                    animator.SetInteger("estado", 3); // Derecha
            }
            else
            {
                if (diferenciaY > 0)
                    animator.SetInteger("estado", 4); // Arriba
                else
                    animator.SetInteger("estado", 5); // Abajo
            }
        }
    }

    public void FinAnimacion()
    {
        animator.SetInteger("estado", 0);
    }

    IEnumerator Guiñar()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            animator.SetInteger("estado", 1);
        }
    }
}
