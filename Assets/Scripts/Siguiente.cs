using UnityEngine;
using UnityEngine.SceneManagement;

public class Siguiente : MonoBehaviour
{
    public void SiguientePantalla()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
