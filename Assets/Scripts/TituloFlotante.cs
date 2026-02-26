/* Autor: Dario Alberto Cuevas
 * Descripción: Componente visual para la Interfaz. Utiliza funciones matemáticas 
 * (Mathf.Sin) para alterar suavemente la posición Y del título, 
 * creando un efecto de levitación constante sin usar animaciones.
 * Fecha de creación: 05/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class TituloFlotante : MonoBehaviour
{
    [Header("Ajustes del Bote")]
    public float velocidad = 3f; 
    public float altura = 15f;  

    private RectTransform rectTransform;
    private Vector2 posicionInicial;

    void Start()
    {
        // Cogemos el componente de la UI que controla la posición
        rectTransform = GetComponent<RectTransform>();

        // Guardamos dónde esta el texto exactamente para usarlo de base
        posicionInicial = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidad) * altura;

        // Se la aplicamos al título
        rectTransform.anchoredPosition = new Vector2(posicionInicial.x, nuevaY);
    }
}