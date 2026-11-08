using System.Collections;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Girar());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Girar()
    {
        while (true)
        {
            Quaternion rotacionInicial = transform.rotation;
            animator.SetInteger("estado",1);
            float tiempo = 0f;
            
            while (tiempo < 1f)
            {
                transform.Rotate(0f, 0f, 360f * Time.deltaTime);
                tiempo += Time.deltaTime;
                yield return null;
            }
            transform.rotation=rotacionInicial;
            animator.SetInteger("estado", 0);


            yield return new WaitForSeconds(2f);
        }
    }
}
