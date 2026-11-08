using UnityEngine;

public class VisibilidadControles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(
           Application.platform == RuntimePlatform.Android ||
           Application.platform == RuntimePlatform.IPhonePlayer
           );

    }

}
