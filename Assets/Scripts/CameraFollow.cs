using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float minY = 0f; 

    void LateUpdate()
    {
        if (target != null)
        {
            // La cámara esté en la posición Y del jugador
            float targetY = target.position.y;

            // Para que no baje más allá del suelo inicial
            float clampedY = Mathf.Max(targetY, minY);

            // Aplicamos la posición (manteniendo X y Z de la cámara)
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }
    }
}