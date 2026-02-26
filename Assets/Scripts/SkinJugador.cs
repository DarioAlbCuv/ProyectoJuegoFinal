/* Autor: Dario Alberto Cuevas
 * Descripción: Script de inicialización. Lee el índice guardado en el menú y 
 * sobrescribe el SpriteRenderer del jugador en la escena de juego.
 * Fecha de creación: 15/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class SkinJugador : MonoBehaviour
{
    public Sprite[] bibliotecaDeNaves;

    void Start()
    {
        // 1. Preguntamos a la memoria que nave esta elegida
        int idEleccion = PlayerPrefs.GetInt("SkinSeleccionada", 0);

        // 2. Si el número es válido, cambiamos el sprite
        if (idEleccion >= 0 && idEleccion < bibliotecaDeNaves.Length)
        {
            GetComponent<SpriteRenderer>().sprite = bibliotecaDeNaves[idEleccion];
        }
    }
}