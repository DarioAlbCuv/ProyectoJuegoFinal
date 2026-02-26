/* Autor: Dario Alberto Cuevas
 * Descripción: Sistema de progresión estética. Lee la coordenada Y del jugador 
 * y utiliza una operación de módulo (%) para ciclar automáticamente 
 * entre un Array de Sprites, creando un bucle visual infinito.
 * Fecha de creación: 20/02/2026
 * Última modificación: 22/02/2026
*/

using UnityEngine;

public class CambiarFondo : MonoBehaviour
{
    [Header("Configuración visual")]
    public SpriteRenderer miSpriteRenderer;
    public Sprite[] listaFondos;

    [Header("Configuración de Altura")]
    public Transform jugador; // Para leer su altura
    public float metrosParaCambiar = 100f; 

    private int indiceActual = 0;

    void Start()
    {
        if (miSpriteRenderer == null)
        {
            miSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (listaFondos.Length > 0)
        {
            miSpriteRenderer.sprite = listaFondos[0];
        }
    }

    void Update()
    {
        if (jugador != null && listaFondos.Length > 0 && metrosParaCambiar > 0)
        {
            // 1. Calculamos el "nivel" de altura total (0, 1, 2, 3, 4, 5...)
            int nivelDeAltura = Mathf.FloorToInt(jugador.position.y / metrosParaCambiar);

            // Evitamos que calcule cosas raras si la nave cae por debajo de 0
            if (nivelDeAltura < 0) nivelDeAltura = 0;

            // 2. Al llegar al nivel 4, esto devuelve 0.
            int nuevoIndice = nivelDeAltura % listaFondos.Length;

            // 3. Si toca cambiar de imagen, la cambiamos
            if (nuevoIndice != indiceActual)
            {
                indiceActual = nuevoIndice;
                miSpriteRenderer.sprite = listaFondos[indiceActual];
            }
        }
    }
}