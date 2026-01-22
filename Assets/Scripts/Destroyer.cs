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