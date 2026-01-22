using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LogicaMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider sliderVolumen;

    void Start()
    {
        // 1. Cargamos el volumen guardado (por defecto 0 si no existe)
        float volGuardado = PlayerPrefs.GetFloat("VolumenGuardado", 0f);

        // 2. Forzamos al Slider a ponerse en esa posición
        if (sliderVolumen != null)
        {
            sliderVolumen.value = volGuardado;
        }

        // 3. Forzamos al Mixer a aplicar ese volumen
        AplicarVolumenAlMixer(volGuardado);

        Debug.Log("Volumen cargado desde memoria: " + volGuardado);
    }

    public void ControlarVolumen(float valorSlider)
    {
        // Se llama cada vez que mueves el slider
        AplicarVolumenAlMixer(valorSlider);

        // Guardamos inmediatamente
        PlayerPrefs.SetFloat("VolumenGuardado", valorSlider);
        PlayerPrefs.Save(); // Fuerza el guardado en el disco
    }

    private void AplicarVolumenAlMixer(float valor)
    {
        if (masterMixer != null)
        {
            masterMixer.SetFloat("VolumenGeneral", valor);
        }
    }
}