using UnityEngine;
using UnityEngine.SceneManagement;

public class Anterior : MonoBehaviour
{
    public void PantallaAnterior()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
