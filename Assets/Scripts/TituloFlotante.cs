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

        // Guardamos dónde pusiste el texto exactamente para usarlo de base
        posicionInicial = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Calculamos la nueva altura usando el "Seno" del tiempo (crea una curva suave)
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidad) * altura;

        // Se la aplicamos al título
        rectTransform.anchoredPosition = new Vector2(posicionInicial.x, nuevaY);
    }
}