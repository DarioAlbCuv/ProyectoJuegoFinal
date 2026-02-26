/* Autor: Dario Alberto Cuevas
 * Descripción: Implementa el Patrón de Diseño Singleton con DontDestroyOnLoad 
 * para asegurar que la música persista ininterrumpida entre escenas.
 * Fecha de creación: 10/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class MusicaContinua : MonoBehaviour
{
    private static MusicaContinua instancia;

    void Awake()
    {
        // Esto saca al objeto de cualquier padre para que pueda ser inmortal
        transform.SetParent(null);

        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}