using UnityEngine;

public class StartingFloor : MonoBehaviour
{
    private Transform cameraTransform;
    public float distanceToDestroy = 10f; // Distancia a la que el suelo desaparece

    void Start()
    {
        // Buscamos la cámara principal al iniciar
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Si la cámara ha subido más de 10 unidades por encima del suelo
        if (cameraTransform.position.y > transform.position.y + distanceToDestroy)
        {
            Debug.Log("Suelo inicial eliminado. Ya no hay red de seguridad.");
            Destroy(gameObject); // El suelo se elimina de la escena
        }
    }
}