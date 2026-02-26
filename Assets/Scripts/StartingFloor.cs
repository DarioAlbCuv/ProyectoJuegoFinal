/* Autor: Dario Alberto Cuevas
 * Descripción: Lógica de inicialización. Garantiza que siempre se instancie una 
 * plataforma estática e indestructible justo debajo del punto 
 * de aparición (spawn) del jugador al inicio de la partida.
 * Fecha de creación: 18/01/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class StartingFloor : MonoBehaviour
{
    private Transform cameraTransform;
    public float distanceToDestroy = 10f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Si la cámara ha subido más de 10 unidades por encima del suelo
        if (cameraTransform.position.y > transform.position.y + distanceToDestroy)
        {
            Destroy(gameObject);
        }
    }
}