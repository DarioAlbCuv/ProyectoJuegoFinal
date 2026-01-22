using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteorito : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject prefabExplosion;
    public AudioClip sonidoExplosion;

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // 1. Sonido: Lo primero para que se oiga antes de que nada se destruya
            if (sonidoExplosion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoExplosion, Camera.main.transform.position);
            }

            // 2. Explosión visual
            Instantiate(prefabExplosion, otro.transform.position, Quaternion.identity);

            // 3. Ocultar la nave
            otro.gameObject.SetActive(false);

            // 4. Reinicio
            Invoke("ReiniciarPartida", 2f);
        }
    }

    void ReiniciarPartida()
    {
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}