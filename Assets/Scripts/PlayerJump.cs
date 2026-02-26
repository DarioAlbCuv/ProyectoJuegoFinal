/* Autor: Dario Alberto Cuevas
 * Descripción: Se encarga exclusivamente de la física vertical. Detecta colisiones 
 * con el Layer de plataformas mediante OnCollisionEnter2D, dispara 
 * el efecto Squash & Stretch y aplica la fuerza de salto automático.
 * Fecha de creación: 16/01/2026
 * Última modificación: 22/02/2026
*/

using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 20f;
    private Rigidbody2D rb;

    [Header("Configuración de Sonido")]
    public AudioSource fuenteAudio;
    public AudioClip sonidoSalto;

    private Animator miAnimador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();

        if (fuenteAudio == null) fuenteAudio = GetComponent<AudioSource>();

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

                if (miAnimador != null)
                {
                    miAnimador.Play("NaveSalto", -1, 0f);
                }

                if (fuenteAudio != null && sonidoSalto != null)
                {
                    // 1. Leemos la memoria
                    float volumenGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
                    float volumenFinal = volumenGuardado * volumenGuardado;

                    // 2. Forzamos el altavoz base a 1, y que el PlayOneShot haga el trabajo matemático
                    fuenteAudio.volume = 1f;
                    fuenteAudio.PlayOneShot(sonidoSalto, volumenFinal);
                }
            }
        }
    }
}