/* Autor: Dario Alberto Cuevas
 * Descripción: Gestiona las plataformas rojas. Activa una invocación de 
 * destrucción retardada (0.5s) tras detectar el contacto con el jugador.
 * Fecha de creación: 26/01/2026
 * Última modificación: 22/02/2026
*/

using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    public float delayBeforeDestroy = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo se destruye si el objeto que choca es el Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificamos que el jugador esté cayendo (pisando la plataforma)
            if (collision.relativeVelocity.y <= 0.1f)
            {
                // Iniciamos la destrucción con retraso
                Invoke("DestroyPlatform", delayBeforeDestroy);
            }
        }
    }

    void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}