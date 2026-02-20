using UnityEngine;
using UnityEngine.UI; 

public class SelectorNave : MonoBehaviour
{
    public Image imagenVisual;
    public Sprite[] listaDeNaves;
    private int indiceActual = 0;

    void Start()
    {
        // 1. Recuperar la última elección
        indiceActual = PlayerPrefs.GetInt("SkinSeleccionada", 0);
        ActualizarVisual();
    }

    public void Siguiente()
    {
        indiceActual++;
        if (indiceActual >= listaDeNaves.Length) 
        {
            indiceActual = 0; 
        }
        ActualizarVisual();
    }

    public void Anterior()
    {
        indiceActual--;
        if (indiceActual < 0) 
        {
            indiceActual = listaDeNaves.Length - 1;
        }
        ActualizarVisual();
    }

    void ActualizarVisual()
    {
        // Cambia la foto
        imagenVisual.sprite = listaDeNaves[indiceActual];

        // GUARDA el dato para la otra escena
        PlayerPrefs.SetInt("SkinSeleccionada", indiceActual);
        PlayerPrefs.Save();
    }
}