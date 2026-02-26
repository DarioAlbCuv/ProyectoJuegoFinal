/* Autor: Dario Alberto Cuevas
 * Descripción: Controla el desplazamiento lateral constante mediante interpolación 
 * matemática para aumentar la dificultad de aterrizaje.
 * Fecha de creación: 25/01/2026
 * Última modificación: 22/02/2026
*/

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private float startX;

    void Start() { startX = transform.position.x; }

    void Update()
    {
        // Movimiento de la plataforma
        float newX = startX + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}