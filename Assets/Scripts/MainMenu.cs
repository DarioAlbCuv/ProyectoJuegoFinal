/* Autor: Dario Alberto Cuevas
 * Descripción: Controlador principal de la navegación del Menú de Inicio. 
 * Gestiona la carga asíncrona de escenas y los paneles de la interfaz.
 * Fecha de creación: 10/01/2026
 * Última modificación: 26/02/2026
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [Header("Paneles de la Interfaz")]
    public GameObject panelCreditos;
    public GameObject panelAjustes;
    public GameObject panelAyuda;
    public GameObject panelTop;

    [Header("Botones para el Foco (Mando/Teclado)")]
    public GameObject botonAjustesPrincipal; // El botón "Ajustes" del menú inicial
    public GameObject primerElementoAjustes; // El primer Slider o botón dentro del panel Ajustes

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        bool pulsaAtrasTeclado = Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
        bool pulsaAtrasMando = Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame;

        if (pulsaAtrasTeclado || pulsaAtrasMando)
        {
            CerrarPaneles();
        }
    }

    public void Jugar() { SceneManager.LoadScene("SampleScene"); }
    public void Salir() { Application.Quit(); }

    // Método exclusivo para abrir Ajustes y mover el cursor
    public void AbrirAjustes()
    {
        panelAjustes.SetActive(true);

        // Limpiamos el foco actual y se lo damos al primer elemento del panel de Ajustes
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(primerElementoAjustes);
    }

    public void CerrarPaneles()
    {
        bool habiaPanelAbierto = panelCreditos.activeSelf || panelAjustes.activeSelf || panelAyuda.activeSelf || panelTop.activeSelf;

        if (panelCreditos != null) panelCreditos.SetActive(false);
        if (panelAjustes != null) panelAjustes.SetActive(false);
        if (panelAyuda != null) panelAyuda.SetActive(false);
        if (panelTop != null) panelTop.SetActive(false);

        // Si hemos cerrado algún panel, devolvemos el foco al menú principal
        if (habiaPanelAbierto)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(botonAjustesPrincipal);
        }
    }
}