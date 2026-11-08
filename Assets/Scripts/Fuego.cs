
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    PolygonCollider2D pc2d;
    Sprite spriteAnterior;
    [SerializeField]
    float activo = 5f;
    [SerializeField]
    float inactivo = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("estado", 0);
        tag="Suelo";
        sprite = GetComponent<SpriteRenderer>();
        pc2d = GetComponent<PolygonCollider2D>();

        StartCoroutine(CicloFuego());
    }

    void Update()
    {
        ActualizarCollider();
    }
    IEnumerator CicloFuego()
    {
        while (true)
        {
            yield return new WaitForSeconds(inactivo);

            animator.SetInteger("estado", 1);
            tag="Obstaculo";

            yield return new WaitForSeconds(activo);

            animator.SetInteger("estado", 0);
            tag="Suelo";
        }
    }
    void ActualizarCollider()
    {
        if (sprite.sprite != spriteAnterior)
        {
            spriteAnterior = sprite.sprite;

            pc2d.pathCount = sprite.sprite.GetPhysicsShapeCount();

            for (int i = 0; i < pc2d.pathCount; i++)
            {
                System.Collections.Generic.List<Vector2> puntos = new();

                sprite.sprite.GetPhysicsShape(i, puntos);

                pc2d.SetPath(i, puntos);
            }
        }
    }
}
