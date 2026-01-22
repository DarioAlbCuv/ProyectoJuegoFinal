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