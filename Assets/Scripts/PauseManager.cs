/* Autor: Dario Alberto Cuevas
 * Descripción: Intercepta el Input de pausa (ESC) para manipular la escala de 
 * tiempo (Time.timeScale) y conmutar la visibilidad de la UI modal.
 * Fecha de creación: 05/02/2026
 * Última modificación: 26/02/2026
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 
using UnityEngine.EventSystems; 

public class PauseManager : MonoBehaviour
{
    public GameObject objetoMenuPausa;
    public GameObject botonContinuar; 

    private bool estaPausado = false;

    //El Update para "escuchar" si pulsas pausa con teclado o mando
    void Update()
    {
        bool pulsaPausaTeclado = Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
        bool pulsaPausaMando = Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame;

        if (pulsaPausaTeclado || pulsaPausaMando)
        {
            ActivarDesactivarPausa();
        }
    }

    public void ActivarDesactivarPausa()
    {
        // Si estaba pausado, lo despausa. Si no estaba, lo pausa.
        if (estaPausado)
        {
            AlternarPausa(false);
        }
        else
        {
            AlternarPausa(true);
        }
    }

    public void AlternarPausa(bool estado)
    {
        estaPausado = estado;
        objetoMenuPausa.SetActive(estado);

        // Si estado es true, el tiempo se congela (0). Si es false, vuelve a la normalidad (1).
        Time.timeScale = estado ? 0f : 1f;

        // Lógica para mover el foco a los botones
        EventSystem.current.SetSelectedGameObject(null); 

        if (estado == true && botonContinuar != null)
        {
            // Si acabamos de pausar, le damos el foco al botón de continuar
            EventSystem.current.SetSelectedGameObject(botonContinuar);
        }
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f; // Evita que el juego empiece congelado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}