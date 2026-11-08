using UnityEngine;
using UnityEngine.InputSystem;

public class MovAdventure : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    LayerMask suelo;
    CapsuleCollider2D cc2d;
    InputAction desplazarse;
    InputAction saltar;
    Vector2 movimiento = new();
    bool recibiendoDano;

    SpriteRenderer sprite;

    [SerializeField]
    float velocidad = 2f;
    float velocidadSalto = 5f;

    int saltos;

    void Saltar()
    {
        if (TocoSuelo())
        {
            saltos = 2;
        }

        if (saltar.WasPressedThisFrame() && (TocoSuelo() || saltos > 1))
        {
            rb2d.linearVelocityY = velocidadSalto;
            saltos--;
        }
    }

    void Moverse()
    {
        if (recibiendoDano)
        {
            rb2d.linearVelocityX = 0;

            if (!TocoSuelo())
                rb2d.linearVelocityY = -15f;

            return;
        }

        movimiento = desplazarse.ReadValue<Vector2>();

        rb2d.linearVelocityX = movimiento.x * velocidad;

        if (movimiento.x != 0)
            animator.SetInteger("estado", 1);

        if (TocoSuelo() && movimiento.x == 0)
            animator.SetInteger("estado", 0);

        if (movimiento.x < 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        if (!DobleSalto() && rb2d.linearVelocityY < 0)
            animator.SetInteger("estado", 3);
        if (!DobleSalto() && rb2d.linearVelocityY > 0)
            animator.SetInteger("estado", 2);

    }
    bool TocoSuelo()
    {
        return Physics2D.BoxCast(cc2d.bounds.center, cc2d.bounds.size, 0f, Vector2.down, .1f, suelo);

    }
    bool DobleSalto()
    {
        Debug.Log(saltos);
        if (saltos == 1 && saltar.WasPressedThisFrame())
        {
            animator.SetInteger("estado", 4);
            return true;
        }
        else return false;

    }
    void Start()
    {
        desplazarse = InputSystem.actions.FindAction("Move");
        saltar = InputSystem.actions.FindAction("Jump");
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        suelo = LayerMask.GetMask("Suelo");
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Saltar();
        Moverse();
        if (recibiendoDano && TocoSuelo())
        {
            recibiendoDano = false;
            rb2d.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") || collision.gameObject.CompareTag("Obstaculo"))
        {
            recibiendoDano = true;
            animator.SetInteger("estado", 5);

            if (!TocoSuelo())
                rb2d.linearVelocity = new(0, -5f);
            else
                rb2d.linearVelocity = Vector2.zero;

        }
    }
}
