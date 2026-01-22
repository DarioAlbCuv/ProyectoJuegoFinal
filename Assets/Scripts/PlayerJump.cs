using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 15f; 
    private Rigidbody2D rb;

    [Header("Configuración de Sonido")]
    public AudioSource fuenteAudio;
    public AudioClip sonidoSalto; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (fuenteAudio == null) fuenteAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobación extra para el Suelo Inicial
        if (collision.gameObject.CompareTag("Plataforma") || collision.gameObject.name == "SueloInicial")
        {
            if (rb != null && rb.velocity.y <= 0.1f)
            {
                rb.velocity = Vector2.up * jumpForce;

                if (fuenteAudio != null && sonidoSalto != null)
                {
                    fuenteAudio.PlayOneShot(sonidoSalto);
                }
            }
        }
    }
}