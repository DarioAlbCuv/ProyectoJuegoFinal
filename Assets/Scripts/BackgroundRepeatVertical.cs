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
        // Movemos el fondo hacia arriba el doble de su altura (asumiendo que tienes 2 fondos)
        transform.Translate(new Vector3(0f, 2 * spriteHeight, 0f));
    }
}