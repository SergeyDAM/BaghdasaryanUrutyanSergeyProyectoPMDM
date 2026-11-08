using System;
using System.Collections;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(esperar());
        }
    }
    IEnumerator esperar()
    {
        yield return new WaitForSeconds(1.5f);
        rb2d.bodyType = RigidbodyType2D.Dynamic;

    }
}
