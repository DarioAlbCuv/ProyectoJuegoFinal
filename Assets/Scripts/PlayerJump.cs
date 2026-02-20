using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 20f;
    private Rigidbody2D rb;

    [Header("Configuración de Sonido")]
    public AudioSource fuenteAudio;
    public AudioClip sonidoSalto;

    // --- 1. LÍNEA AÑADIDA PARA LA ANIMACIÓN ---
    private Animator miAnimador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // --- 2. LÍNEA AÑADIDA PARA LA ANIMACIÓN ---
        miAnimador = GetComponent<Animator>();

        if (fuenteAudio == null) fuenteAudio = GetComponent<AudioSource>();

        // --- ¡AQUÍ ESTÁ LA MAGIA QUE FALTABA! ---
        if (fuenteAudio != null)
        {
            // Leemos el volumen de los efectos que guardaste en el menú
            float volumenGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);

            // Le aplicamos la curva logarítmica (valor * valor) al altavoz del salto
            fuenteAudio.volume = volumenGuardado * volumenGuardado;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma") || collision.gameObject.name == "SueloInicial")
        {
            if (rb != null && rb.velocity.y <= 0.1f)
            {
                rb.velocity = Vector2.up * jumpForce;

                // --- 3. LÍNEAS AÑADIDAS PARA LA ANIMACIÓN (EL GATILLO) ---
                if (miAnimador != null)
                {
                    miAnimador.Play("NaveSalto", -1, 0f);
                }

                if (fuenteAudio != null && sonidoSalto != null)
                {
                    // 1. Leemos la memoria
                    float volumenGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
                    float volumenFinal = volumenGuardado * volumenGuardado;

                    // --- CHIVATO PARA LA CONSOLA ---
                    Debug.Log("?? SALTO! Memoria dice: " + volumenGuardado + " | Volumen real aplicado: " + volumenFinal);

                    // 2. Forzamos el altavoz base a 1, y que el PlayOneShot haga el trabajo matemático
                    fuenteAudio.volume = 1f;
                    fuenteAudio.PlayOneShot(sonidoSalto, volumenFinal);
                }
            }
        }
    }
}