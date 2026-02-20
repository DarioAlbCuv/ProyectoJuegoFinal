using UnityEngine;

public class SkinJugador : MonoBehaviour
{
    // Esta lista tiene que ser gemela a la del menú
    public Sprite[] bibliotecaDeNaves;

    void Start()
    {
        // 1. Preguntamos a la memoria que nave esta elegida
        int idEleccion = PlayerPrefs.GetInt("SkinSeleccionada", 0);

        // 2. Seguridad: Si el número es válido, cambiamos el sprite
        if (idEleccion >= 0 && idEleccion < bibliotecaDeNaves.Length)
        {
            GetComponent<SpriteRenderer>().sprite = bibliotecaDeNaves[idEleccion];
        }
    }
}