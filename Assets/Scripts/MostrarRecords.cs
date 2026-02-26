/* Autor: Dario Alberto Cuevas
 * Descripción: Lee la estructura de datos guardada (Top 10) y la formatea 
 * dinámicamente en los componentes de TextMeshPro de la interfaz 
 * para mostrar la tabla de clasificación al jugador.
 * Fecha de creación: 18/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;
using TMPro; 

public class MostrarRecords : MonoBehaviour
{
    public TextMeshProUGUI textoTop10;

    void Start()
    {
        textoTop10.text = "--- TOP 10 PILOTOS ---\n\n";

        // 1. Un bucle que lee del puesto 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            // Leemos la memoria 
            string nombre = PlayerPrefs.GetString("Name" + i, "---");
            int puntos = PlayerPrefs.GetInt("Score" + i, 0);

            // 2. Añadimos la línea al texto final
            textoTop10.text += i + ". " + nombre + " - " + puntos + " pts\n";
        }
    }
}