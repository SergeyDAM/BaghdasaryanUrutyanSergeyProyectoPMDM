using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bienvenida : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Siguiente());
    }
    IEnumerator Siguiente()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
