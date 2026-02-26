/* Autor: Dario Alberto Cuevas
 * Descripción: Lógica individual del proyectil. Controla su traslación constante 
 * y lanza el evento de Game Over si su Trigger intercepta al jugador.
 * Fecha de creación: 02/02/2026
 * Última modificación: 22/02/2026
*/

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

            int puntosFinales = FindObjectOfType<ScoreManager>().ObtenerPuntuacionFinal();
            FindObjectOfType<GestorRecords>().ProcesarMuerte(puntosFinales);

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