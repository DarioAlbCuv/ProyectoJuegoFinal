using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GuardarNombre : MonoBehaviour
{
    public TMP_InputField inputNombre; 

    void Start()
    {
        // Si el jugador ya jugó ayer, le autocompletamos el nombre
        if (inputNombre != null)
        {
            inputNombre.text = PlayerPrefs.GetString("JugadorActual", "");
        }
    }

    public void BotonJugar()
    {
        string nombre = inputNombre.text;

        // Si el jugador le da a jugar sin escribir nada, le ponemos un nombre por defecto
        if (string.IsNullOrEmpty(nombre))
        {
            nombre = "Piloto Desconocido";
        }

        // 1. GUARDAMOS EL NOMBRE EN LA MEMORIA
        PlayerPrefs.SetString("JugadorActual", nombre);
        PlayerPrefs.Save();

        // 2. CARGAMOS LA ESCENA DEL JUEGO
        SceneManager.LoadScene("SampleScene");
    }
}