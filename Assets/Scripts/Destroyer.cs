/* Autor: Dario Alberto Cuevas
 * Descripción: Componente utilitario de optimización. 
 * Destruye los objetos que salen por el límite inferior de la 
 * pantalla para liberar memoria RAM y evitar caídas de FPS.
 * Fecha de creación: 18/01/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Update()
    {
        // Si la cámara sube y la plataforma queda muy abajo, se destruye para liberar memoria
        if (Camera.main.transform.position.y > transform.position.y + 10f)
        {
            Destroy(gameObject);
        }
    }
}