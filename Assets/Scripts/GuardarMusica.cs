using UnityEngine;

public class GuardarMusica : MonoBehaviour
{
    void Start()
    {
        AudioSource miAudio = GetComponent<AudioSource>();

        if (miAudio != null)
        {
            // 1. Buscamos EXACTAMENTE la misma palabra que usa el Slider ("VolumenMusica")
            float vol = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);

            // 2. Le aplicamos el volumen matemático a la música nada más arrancar
            miAudio.volume = vol * vol;
        }
    }
}