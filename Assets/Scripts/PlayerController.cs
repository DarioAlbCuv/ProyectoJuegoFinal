using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // 1. ¡AÑADIDA LA LIBRERÍA DEL INPUT SYSTEM!

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    private Rigidbody2D rb;
    private float horizontalInput;

    // 1. Variable para guardar el altavoz de la nave
    private AudioSource miAudioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // --- NUEVO: Leer el volumen de SFX guardado en el menú ---
        miAudioSource = GetComponent<AudioSource>();

        // Comprobamos si la nave tiene un AudioSource puesto
        if (miAudioSource != null)
        {
            // Leemos el valor (0.5 por defecto si es la primera vez que juega)
            float volumenGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
            // Aplicamos la curva logarítmica (valor * valor)
            miAudioSource.volume = volumenGuardado * volumenGuardado;
        }
    }

    void OnMove(InputValue valor)
    {
        // Cogemos el valor de las flechas (X e Y) y nos guardamos solo la X
        Vector2 movimiento = valor.Get<Vector2>();
        horizontalInput = movimiento.x;
    }


    void OnPause(InputValue valor)
    {
        if (valor.isPressed)
        {
            // Buscamos tu PauseManager en la escena y le decimos que active/desactive la pausa
            FindObjectOfType<PauseManager>().ActivarDesactivarPausa();
        }
    }


    void Update()
    {
        // Aplicar velocidad lateral manteniendo la del salto usando el nuevo valor
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
            // 1. Preguntamos cuántos puntos conseguimos
            int puntosFinales = FindObjectOfType<ScoreManager>().ObtenerPuntuacionFinal();

            // 2. Se los mandamos al Gestor de Récords
            FindObjectOfType<GestorRecords>().ProcesarMuerte(puntosFinales);

            // 3. Reiniciamos el nivel
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Si el jugador cae por debajo del suelo inicial (ejemplo: Y = -5)
        else if (transform.position.y < -5f)
        {
            Debug.Log("Game Over");

            // 1. Preguntamos cuántos puntos conseguimos
            int puntosFinales = FindObjectOfType<ScoreManager>().ObtenerPuntuacionFinal();

            // 2. Se los mandamos al Gestor de Récords
            FindObjectOfType<GestorRecords>().ProcesarMuerte(puntosFinales);

            // 3. Reiniciamos la escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}