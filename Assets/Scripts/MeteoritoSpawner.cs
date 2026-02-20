using UnityEngine;
using System.Collections; // 1. ¡OJO! Necesitamos esto para usar Corrutinas

public class MeteoritoSpawner : MonoBehaviour
{
    public GameObject[] prefabsMeteoritos;
    public Transform jugador;

    [Header("Ajustes de Dificultad")]
    public float tiempoSpawn = 3f;       // Tiempo inicial entre meteoritos
    public float tiempoMinimo = 0.6f;    // El límite máximo de rapidez (para que no sea imposible)

    // 2. Este es el truco para que NO sea lineal. 
    // Multiplicaremos el tiempo por 0.95 (le quitamos un 5% de tiempo cada vez que sale uno)
    public float multiplicadorDificultad = 0.95f;

    void Start()
    {
        ActualizarReferenciaJugador();

        // 3. Arrancamos el motor de la dificultad progresiva
        StartCoroutine(RutinaDeGeneracion());
    }

    void ActualizarReferenciaJugador()
    {
        GameObject jugadorObj = GameObject.FindWithTag("Player");
        if (jugadorObj != null) jugador = jugadorObj.transform;
    }

    // --- LA CORRUTINA MÁGICA ---
    IEnumerator RutinaDeGeneracion()
    {
        // Retraso inicial de 2 segundos antes de empezar a escupir meteoritos
        yield return new WaitForSeconds(2f);

        while (true) // Este bucle se repetirá hasta que mueras
        {
            SpawnLogica(); // Creamos el meteorito

            // ¡AQUÍ ESTÁ LO QUE PIDE EL PROFESOR!
            // Reducimos el tiempo un 5%. Al ser una multiplicación, la curva de dificultad es Exponencial (no lineal).
            tiempoSpawn = Mathf.Max(tiempoMinimo, tiempoSpawn * multiplicadorDificultad);

            // Le decimos a Unity: "Espera este nuevo tiempo antes de volver a empezar el bucle"
            yield return new WaitForSeconds(tiempoSpawn);
        }
    }

    void SpawnLogica()
    {
        if (jugador == null)
        {
            ActualizarReferenciaJugador();
            if (jugador == null) return;
        }

        float puntuacion = jugador.position.y;
        int indiceMeteorito = 0;

        // FASE 1: meteoritos pequeños (0) y medianos (1)
        if (puntuacion < 150)
        {
            indiceMeteorito = Random.Range(0, 2);
        }
        // FASE 2: dejan de salir los pequeños (0). Salen: 1 y 2.
        else if (puntuacion >= 150 && puntuacion < 250)
        {
            indiceMeteorito = Random.Range(1, 3);
        }
        // FASE 3: EXPERTA. Salen grandes y gigantes: 0, 1, 2, 3 (puse el 4 porque Random.Range con ints excluye el último número)
        else if (puntuacion >= 250)
        {
            indiceMeteorito = Random.Range(0, 4);
        }

        Spawn(indiceMeteorito);
    }

    void Spawn(int indice)
    {
        // Aparecen a la derecha del jugador
        Vector3 pos = new Vector3(jugador.position.x + 12f, jugador.position.y + Random.Range(7f, 12f), 0);
        Instantiate(prefabsMeteoritos[indice], pos, Quaternion.identity);
    }
}