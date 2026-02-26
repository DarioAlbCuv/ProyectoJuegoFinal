/* Autor: Dario Alberto Cuevas
 * Descripción: Lógica del carrusel de selección. Permite ciclar por un Array de 
 * Sprites y guarda el índice elegido por el usuario en memoria local.
 * Fecha de creación: 15/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;
using UnityEngine.UI; 

public class SelectorNave : MonoBehaviour
{
    public Image imagenVisual;
    public Sprite[] listaDeNaves;
    private int indiceActual = 0;

    void Start()
    {
        // 1. Recuperar la última elección
        indiceActual = PlayerPrefs.GetInt("SkinSeleccionada", 0);
        ActualizarVisual();
    }

    public void Siguiente()
    {
        indiceActual++;
        if (indiceActual >= listaDeNaves.Length) 
        {
            indiceActual = 0; 
        }
        ActualizarVisual();
    }

    public void Anterior()
    {
        indiceActual--;
        if (indiceActual < 0) 
        {
            indiceActual = listaDeNaves.Length - 1;
        }
        ActualizarVisual();
    }

    void ActualizarVisual()
    {
        // Cambia la foto
        imagenVisual.sprite = listaDeNaves[indiceActual];

        // Guarda el dato para la otra escena
        PlayerPrefs.SetInt("SkinSeleccionada", indiceActual);
        PlayerPrefs.Save();
    }
}