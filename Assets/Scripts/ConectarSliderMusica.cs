using UnityEngine;
using UnityEngine.UI;

public class ConectarSliderMusica : MonoBehaviour
{
    void Start()
    {
        // 1. Buscamos el objeto (el que tiene el AudioSource)
        GameObject musicaObjeto = GameObject.Find("Musica");

        if (musicaObjeto != null)
        {
            Slider miSlider = GetComponent<Slider>();
            AudioSource fuenteAudio = musicaObjeto.GetComponent<AudioSource>();

            // 2. Sincronizamos la posición de la barra con el volumen real
            miSlider.value = fuenteAudio.volume;

            // 3. Limpiamos eventos viejos para evitar errores
            miSlider.onValueChanged.RemoveAllListeners();

            // 4. Conectamos el slider a la función de volumen dinámicamente
            miSlider.onValueChanged.AddListener(delegate {
                fuenteAudio.volume = miSlider.value;
                // También guardamos el valor
                PlayerPrefs.SetFloat("VolumenGuardado", miSlider.value);
            });
        }
    }
}