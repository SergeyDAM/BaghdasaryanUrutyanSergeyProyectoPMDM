
using UnityEngine;
using UnityEngine.InputSystem;

public class MovEnemigoY : MonoBehaviour
{
    Rigidbody2D rb2d;
    float distancia = 0;
    [SerializeField]
    float velocidad = 2f;
    int direccion = 1;
    [SerializeField]
    float distanciaMaxima = 9f;
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, direccion * velocidad * Time.deltaTime, 0);

        distancia += velocidad * Time.deltaTime;

        if (distancia >= distanciaMaxima)
        {
            direccion *= -1;
            distancia = 0;
            sprite.flipX=!sprite.flipX;
        }

    }

}
