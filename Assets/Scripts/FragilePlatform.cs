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
        // Puedes añadir aquí un efecto de sonido o partículas antes de borrarla
        Destroy(gameObject);
    }
}