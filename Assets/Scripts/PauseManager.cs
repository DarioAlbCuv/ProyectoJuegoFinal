using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject objetoMenuPausa;
    private bool estaPausado = false;

    void Update()
    {
        // Si pulsas ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado) AlternarPausa(false);
            else AlternarPausa(true);
        }
    }

    public void AlternarPausa(bool estado)
    {
        estaPausado = estado;
        objetoMenuPausa.SetActive(estado);

        // Si estado es true, el tiempo se congela (0). Si es false, vuelve a la normalidad (1).
        Time.timeScale = estado ? 0f : 1f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f; // Evita que el juego empieza congelado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}