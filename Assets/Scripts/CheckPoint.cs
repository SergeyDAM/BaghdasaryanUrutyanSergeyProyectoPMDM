using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    Animator animator;
    int estado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estado=1;
        }
        animator.SetInteger("estado",estado);
    }

    void Victoria()
    {
        SceneManager.LoadScene("Victoria");
    }
    
}
