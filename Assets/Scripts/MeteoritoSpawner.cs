using UnityEngine;

public class MeteoritoSpawner : MonoBehaviour
{
    public GameObject[] prefabsMeteoritos;
    public Transform jugador;
    public float tiempoSpawn = 3f;

    void Start()
    {
        ActualizarReferenciaJugador();
        // Inicia el ciclo de creación
        InvokeRepeating("SpawnLogica", 2f, tiempoSpawn);
    }

    void ActualizarReferenciaJugador()
    {
        GameObject jugadorObj = GameObject.FindWithTag("Player");
        if (jugadorObj != null) jugador = jugadorObj.transform;
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

        

        // 2. FASE INICIAL meteoritos pequeños (0) y medianos (1)
        if (puntuacion < 150 && puntuacion < 250)
        {
            indiceMeteorito = Random.Range(0, 2);
        }
        // 3. FASE MEDIA dejan de salir los pequeños (0). Salen: 1 y 2.
        else if (puntuacion >= 250 && puntuacion < 500)
        {
            indiceMeteorito = Random.Range(1, 3);
        }
        // 4. FASE EXPERTA solo meteoritos grandes y gigantes. Salen: 2 y 3.
        else if (puntuacion >= 500)
        {
            indiceMeteorito = Random.Range(2, 4);
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