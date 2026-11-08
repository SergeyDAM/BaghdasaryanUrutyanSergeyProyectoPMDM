using System;
using UnityEngine;

public class BolaPincho : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 posicionInicial;
    System.Random random;
    float distancia;
    double numero;
    float altura;
    int desde;
    int hasta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        desde = (int)transform.position.x;
        hasta = desde + 10;
        altura = transform.position.y;
        random = new System.Random();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityY = -5;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            transform.position = new Vector2(random.Next(desde, hasta), altura);
        }
    }
}
