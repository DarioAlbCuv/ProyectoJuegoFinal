using UnityEngine;
using TMPro; 

public class MostrarRecords : MonoBehaviour
{
    public TextMeshProUGUI textoTop10;

    void Start()
    {
        // 1. Ponemos el título de la tabla
        textoTop10.text = "--- TOP 10 PILOTOS ---\n\n";

        // 2. Un bucle que lee del puesto 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            // Leemos la memoria (si no hay nadie, pondrá "---" y "0")
            string nombre = PlayerPrefs.GetString("Name" + i, "---");
            int puntos = PlayerPrefs.GetInt("Score" + i, 0);

            // 3. Añadimos la línea al texto final
            textoTop10.text += i + ". " + nombre + " - " + puntos + " pts\n";
        }
    }
}