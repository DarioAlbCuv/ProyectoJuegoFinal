using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Lista de Prefabs")]
    public GameObject[] platformPrefabs;
    public Transform playerTransform;

    [Header("Configuración de Generación")]
    public float levelWidth = 7f;
    public float minY = 1.5f;
    public float maxY = 3.5f;

    [Header("Control de Distancia")]
    public float spawnThreshold = 10f; // Distancia por encima del jugador para crear plataformas
    private float lastSpawnY = 0f;     // Posición Y de la última plataforma creada

    void Start()
    {
        // Creamos unas cuantas plataformas iniciales para empezar
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Si el jugador está cerca de la última plataforma creada, generamos otra
        if (playerTransform.position.y > lastSpawnY - spawnThreshold)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        // Elige un número al azar entre los tipos de plataformas que tengas
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject prefabToSpawn = platformPrefabs[randomIndex];

        Vector3 spawnPosition = new Vector3();

        // La nueva plataforma se crea por encima de la última
        lastSpawnY += Random.Range(minY, maxY);
        spawnPosition.y = lastSpawnY;
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}