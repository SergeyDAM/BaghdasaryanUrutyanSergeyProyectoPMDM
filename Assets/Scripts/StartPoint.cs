using UnityEngine;

public class StartPoint : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         animator.SetInteger("estado",1);   
        }
    }

    void StandBy()
    {
        animator.SetInteger("estado",0);
    }
}
