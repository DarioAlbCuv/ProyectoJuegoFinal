/* Autor: Dario Alberto Cuevas
 * Descripción: Centraliza el guardado de los parámetros de audio (SFX y Música). 
 * Se asegura de leer las preferencias exactas de volumen mediante 
 * PlayerPrefs al iniciar una nueva sesión de juego.
 * Fecha de creación: 12/02/2026
 * Última modificación: 22/02/2026
*/
using UnityEngine;

public class GuardarMusica : MonoBehaviour
{
    void Start()
    {
        AudioSource miAudio = GetComponent<AudioSource>();

        if (miAudio != null)
        {
            // 1. Buscamos la misma palabra que usa el Slider ("VolumenMusica")
            float vol = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);

            // 2. Le aplicamos el volumen matemático a la música nada más arrancar
            miAudio.volume = vol * vol;
        }
    }
}