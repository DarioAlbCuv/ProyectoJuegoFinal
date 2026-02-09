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