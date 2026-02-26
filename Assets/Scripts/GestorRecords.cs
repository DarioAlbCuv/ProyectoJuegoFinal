/* Autor: Dario Alberto Cuevas
 * Descripción: Controla la serialización y recuperación de la tabla de Top 10 
 * Puntuaciones utilizando PlayerPrefs para garantizar su persistencia.
 * Fecha de creación: 18/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class GestorRecords : MonoBehaviour
{
    public void ProcesarMuerte(int puntosFinales)
    {
        // 1. Recuperamos el nombre que se guardó en el menú
        string nombreJugador = PlayerPrefs.GetString("JugadorActual", "Desconocido");

        // 2. Comprobamos si entra en el Top 10
        for (int i = 1; i <= 10; i++)
        {
            int puntosPuestoActual = PlayerPrefs.GetInt("Score" + i, 0);

            // Si los puntos de ahora son mayores que los de este puesto
            if (puntosFinales > puntosPuestoActual)
            {
                // Empujamos a los que están por debajo un puesto hacia abajo
                for (int j = 10; j > i; j--)
                {
                    PlayerPrefs.SetInt("Score" + j, PlayerPrefs.GetInt("Score" + (j - 1), 0));
                    PlayerPrefs.SetString("Name" + j, PlayerPrefs.GetString("Name" + (j - 1), "---"));
                }

                // Guardamos al jugador en su nuevo trono
                PlayerPrefs.SetInt("Score" + i, puntosFinales);
                PlayerPrefs.SetString("Name" + i, nombreJugador);
                PlayerPrefs.Save(); // Confirmamos el guardado

                break;
            }
        }
    }
}