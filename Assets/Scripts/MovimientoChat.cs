
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoChat : MonoBehaviour
{
    // Componentes de Unity
    Transform camara;
    Animator animator;
    Rigidbody2D rb2d;
    CapsuleCollider2D cc2d;
    SpriteRenderer sprite;
    VidaJugador vidaJugador;

    // Controles
    InputAction desplazarse;
    InputAction saltar;

    AudioSource sonidoDaño;
    AudioSource sonidoSalto;

    // Movimiento
    Vector2 movimiento = new();
    [SerializeField]
    float velocidad = 6f;
    float velocidadSalto = 5f;

    // Suelo y saltos
    LayerMask suelo;
    int saltos;

    // Estado del personaje
    bool recibiendoDano;
    bool empujado;


    // INICIALIZACIÓN

    void Start()
    {
        desplazarse = InputSystem.actions.FindAction("Move");
        saltar = InputSystem.actions.FindAction("Jump");

        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        suelo = LayerMask.GetMask("Suelo");
        camara = Camera.main.transform;
        vidaJugador = GetComponent<VidaJugador>();
        AudioSource[] sonidos = GetComponents<AudioSource>();
        sonidoSalto = sonidos[0];
        sonidoDaño = sonidos[1];

    }


    // ACTUALIZACIÓN

    void Update()
    {
        camara.position = new Vector3(transform.position.x, transform.position.y, camara.position.z);
        Saltar();
        Moverse();

        // Recupera el control cuando toca el suelo después del empujón
        if (empujado && TocoSuelo() && rb2d.linearVelocityY <= 0f)
        {
            empujado = false;
        }
    }


    // SALTO Y DOBLE SALTO

    void Saltar()
    {
        if (empujado)
        {
            return;
        }
        // Comprueba si está en el suelo y no está subiendo
        bool enSuelo = TocoSuelo() && rb2d.linearVelocityY <= 0f;

        // Recupera los dos saltos al aterrizar
        if (enSuelo)
        {
            saltos = 2;
        }

        // Solo salta si se pulsa el botón y quedan saltos disponibles
        if (saltar.WasPressedThisFrame() && (enSuelo || saltos > 0))
        {
            // Comprueba si este salto es el segundo
            bool esDobleSalto = !enSuelo && saltos == 1;

            // Ejecuta el salto y descuenta uno del contador
            sonidoSalto.Play();
            rb2d.linearVelocityY = velocidadSalto;
            saltos--;

            // Activa la animación del doble salto
            if (esDobleSalto)
            {
                animator.SetInteger("estado", 4);
            }
        }
    }


    // MOVIMIENTO Y ANIMACIONES

    void Moverse()
    {
        if (empujado)
        {
            return;
        }
        // Si recibe daño, no puede moverse normalmente
        if (recibiendoDano)
        {
            rb2d.linearVelocityX = 0;

            if (!TocoSuelo())
            {
                rb2d.linearVelocityY = -5f;
            }

            return;
        }

        // Lee el movimiento del jugador
        movimiento = desplazarse.ReadValue<Vector2>();
        rb2d.linearVelocityX = movimiento.x * velocidad;

        // Comprueba si está en el suelo
        bool enSuelo = TocoSuelo() && rb2d.linearVelocityY <= 0f;

        // Mantiene la animación del doble salto mientras asciende
        bool mantenerDobleSalto =
            animator.GetInteger("estado") == 4 &&
            rb2d.linearVelocityY > 0f &&
            !enSuelo;

        // Animación de correr
        if (movimiento.x != 0 && !mantenerDobleSalto)
        {
            animator.SetInteger("estado", 1);
        }

        // Animación de estar quieto
        if (enSuelo && movimiento.x == 0)
        {
            animator.SetInteger("estado", 0);
        }

        // Gira el personaje según la dirección del movimiento
        if (movimiento.x < 0)
        {
            sprite.flipX = true;
        }
        else if (movimiento.x > 0)
        {
            sprite.flipX = false;
        }

        // Animación de caída
        if (!mantenerDobleSalto && rb2d.linearVelocityY < -0.01)
        {
            animator.SetInteger("estado", 3);
        }

        // Animación del salto normal
        if (!mantenerDobleSalto && rb2d.linearVelocityY > 0.01)
        {
            animator.SetInteger("estado", 2);
        }
    }


    // DETECCIÓN DEL SUELO

    bool TocoSuelo()
    {
        return Physics2D.BoxCast(
            cc2d.bounds.center,
            cc2d.bounds.size,
            0f,
            Vector2.down,
            .1f,
            suelo
        );
    }


    // RECEPCIÓN DE DAÑO

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si choca con un enemigo o un obstáculo
        if (collision.gameObject.CompareTag("Enemigo") ||
            collision.gameObject.CompareTag("Obstaculo"))
        {
            recibiendoDano = true;
            sonidoDaño.Play();
            // Activa la animación de daño
            animator.SetInteger("estado", 5);

            // Empuja al jugador en dirección contraria al objeto
            Empujar(collision.transform.position);

            // Hace que caiga si está en el aire
            if (!TocoSuelo() && !empujado)
            {
                rb2d.linearVelocity = new Vector2(
                    rb2d.linearVelocityX,
                    -5f
                );
            }
            else if (!empujado)
            {
                rb2d.linearVelocity = Vector2.zero;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba si choca con un enemigo o un obstáculo
        if (collision.gameObject.CompareTag("Enemigo") ||
            collision.gameObject.CompareTag("Obstaculo"))
        {
            recibiendoDano = true;
            sonidoDaño.Play();
            // Activa la animación de daño
            animator.SetInteger("estado", 5);

            // Empuja al jugador en dirección contraria al objeto
            Empujar(collision.transform.position);

            // Hace que caiga si está en el aire
            if (!TocoSuelo() && !empujado)
            {
                rb2d.linearVelocity = new Vector2(
                    rb2d.linearVelocityX,
                    -5f
                );
            }
            else if (!empujado)
            {
                rb2d.linearVelocity = Vector2.zero;
            }
        }
    }
    public void Empujar(Vector2 posicionBloque)
    {
        float direccion = Mathf.Sign(transform.position.x - posicionBloque.x);

        empujado = true;
        rb2d.linearVelocity = new Vector2(direccion * 3f, 3f);
    }

    public void RecuperarControl()
    {
        empujado = false;
        saltos = 2;
    }

    void subidaVentilador()
    {
        if (rb2d.linearVelocityY > 0f)
        {
            animator.SetInteger("estado", 2);
        }

    }

    public void FinalizarDano()
    {
        vidaJugador.RecibirDano();

        recibiendoDano = false;
        empujado = false;

        rb2d.linearVelocity = Vector2.zero;

        saltos = 2;

        animator.SetInteger("estado", 0);
    }
}
