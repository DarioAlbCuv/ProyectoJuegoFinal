/* Autor: Dario Alberto Cuevas
 * Descripción: Sistema de optimización de entorno. Reposiciona las texturas de 
 * fondo verticalmente basándose en la posición de la cámara, 
 * creando la ilusión de un fondo espacial infinito.
 * Fecha de creación: 18/01/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class BackgroundRepeatVertical : MonoBehaviour
{
    private float spriteHeight;

    void Start()
    {
        // Obtenemos el colisionador para saber cuánto mide de alto la imagen
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        spriteHeight = backgroundCollider.size.y;
    }

    void Update()
    {
        // Verificamos si la cámara ha pasado el punto medio del fondo
        // Si la cámara sube más allá de la posición del fondo + su altura
        if (Camera.main.transform.position.y > transform.position.y + spriteHeight)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Movemos el fondo hacia arriba el doble de su altura
        transform.Translate(new Vector3(0f, 2 * spriteHeight, 0f));
    }
}