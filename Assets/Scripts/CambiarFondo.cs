using UnityEngine;

public class CambiarFondo : MonoBehaviour
{
    [Header("Configuración visual")]
    public SpriteRenderer miSpriteRenderer;
    public Sprite[] listaFondos; // Aquí meteremos tus 4 fondos

    [Header("Configuración de Altura")]
    public Transform jugador; // Para leer su altura
    public float metrosParaCambiar = 100f; // Cada cuánta altura cambia el fondo

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

            // 2. LA MAGIA DEL BUCLE (%): Si tienes 4 fondos, al llegar al nivel 4, esto devuelve 0.
            int nuevoIndice = nivelDeAltura % listaFondos.Length;

            // 3. Si toca cambiar de imagen, la cambiamos
            if (nuevoIndice != indiceActual)
            {
                indiceActual = nuevoIndice;
                miSpriteRenderer.sprite = listaFondos[indiceActual];

                Debug.Log("?? ¡Bucle de fondos! Cambiando a la imagen número: " + (indiceActual + 1));
            }
        }
    }
}