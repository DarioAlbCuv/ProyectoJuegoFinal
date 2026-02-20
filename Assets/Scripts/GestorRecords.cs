using UnityEngine;

public class GestorRecords : MonoBehaviour
{
    // Llama a esta función desde tu script de Salud o GameManager CUANDO EL JUGADOR MUERA
    public void ProcesarMuerte(int puntosFinales)
    {
        // 1. Recuperamos el nombre que se guardó en el menú
        string nombreJugador = PlayerPrefs.GetString("JugadorActual", "Desconocido");

        // 2. Comprobamos si entra en el Top 10
        for (int i = 1; i <= 10; i++)
        {
            int puntosPuestoActual = PlayerPrefs.GetInt("Score" + i, 0);

            // Si los puntos de ahora son mayores que los de este puesto...
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

                Debug.Log("¡Récord guardado! " + nombreJugador + " está en el puesto " + i);
                break; // Rompemos el bucle para no ocupar los 10 puestos a la vez
            }
        }
    }
}