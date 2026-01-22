using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Leer teclado (Flechas o A/D)
        horizontalInput = Input.GetAxis("Horizontal");

        // Aplicar velocidad lateral manteniendo la del salto
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        float screenLimit = 8.3f;

        if (transform.position.x > screenLimit)
        {
            // Si sale por la derecha, aparece en el extremo izquierdo
            transform.position = new Vector3(-screenLimit + 0.1f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -screenLimit)
        {
            // Si sale por la izquierda, aparece en el extremo derecho
            transform.position = new Vector3(screenLimit - 0.1f, transform.position.y, transform.position.z);
        }

        // Si el jugador cae 10 metros por debajo de la cámara actual
        if (transform.position.y < Camera.main.transform.position.y - 10f)
        {
            // Reiniciar el nivel actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Si el jugador cae por debajo del suelo inicial (ejemplo: Y = -2)
        if (transform.position.y < -5f)
        {
            Debug.Log("Game Over");
            // Reiniciar la escena
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

}