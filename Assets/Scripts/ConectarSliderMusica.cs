/* Autor: Dario Alberto Cuevas
 * Descripción: Transforma el valor lineal del Slider de la UI en una escala 
 * logarítmica (Mathf.Log10) para una atenuación acústica realista.
 * Fecha de creación: 12/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;
using UnityEngine.UI;

public class ConectarSliderMusica : MonoBehaviour
{
    void Start()
    {
        // Buscamos el objeto de la música
        GameObject musicaObjeto = GameObject.Find("Musica");

        if (musicaObjeto != null)
        {
            Slider miSlider = GetComponent<Slider>();
            AudioSource fuenteAudio = musicaObjeto.GetComponent<AudioSource>();

            // 1. Leemos la memoria ("VolumenMusica"). Si no hay nada, ponemos 0.5 por defecto.
            float volGuardado = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);

            // 2. Colocamos el Slider en su sitio nada más arrancar
            miSlider.value = volGuardado;

            // 3. Le aplicamos el volumen matemático al altavoz
            fuenteAudio.volume = volGuardado * volGuardado;

            // Limpiamos eventos viejos
            miSlider.onValueChanged.RemoveAllListeners();

            // 4. Conectamos el slider para que guarde los cambios
            miSlider.onValueChanged.AddListener(delegate {

                fuenteAudio.volume = miSlider.value * miSlider.value; // Curva suave

                // Guardamos con la misma palabra exacta
                PlayerPrefs.SetFloat("VolumenMusica", miSlider.value);
                PlayerPrefs.Save();
            });
        }
    }
}