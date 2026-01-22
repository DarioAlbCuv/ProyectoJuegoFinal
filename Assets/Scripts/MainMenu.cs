using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Asegura que el tiempo corra normal al entrar al menú
        Time.timeScale = 1f;
    }

    // Este método lo llamará el botón Jugar
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Este método lo llamará el botón Salir
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}