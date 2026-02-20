using UnityEngine;
using UnityEngine.UI;

public class SliderEfectos : MonoBehaviour
{
    [Header("Configuración de Audio")]
    public AudioSource fuenteEfectos;
    public AudioClip sonidoSalto;

    private Slider miSlider;

    void Start()
    {
        miSlider = GetComponent<Slider>();

        if (fuenteEfectos != null)
        {
            // Leemos el volumen de la memoria al abrir el menú (0.5 por defecto)
            float volGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
            miSlider.value = volGuardado;
            fuenteEfectos.volume = volGuardado * volGuardado; // Curva logarítmica
        }

        miSlider.onValueChanged.RemoveAllListeners();
        miSlider.onValueChanged.AddListener(CambiarVolumen);
    }

    void CambiarVolumen(float valor)
    {
        if (fuenteEfectos != null)
        {
            // 1. Aplicamos el volumen real al altavoz
            fuenteEfectos.volume = valor * valor;

            // 2. Guardamos el ajuste en memoria
            PlayerPrefs.SetFloat("VolumenSFX", valor);
            PlayerPrefs.Save();

            // 3. ¡EL FIX! Si la barra está abajo del todo (casi 0), NO reproducimos nada
            if (valor > 0.01f)
            {
                // Si no está sonando ya, lo reproducimos
                if (!fuenteEfectos.isPlaying && sonidoSalto != null)
                {
                    fuenteEfectos.clip = sonidoSalto;
                    fuenteEfectos.Play(); // Usamos Play normal en vez de PlayOneShot para que obedezca al volumen 100%
                }
            }
            else
            {
                // Si lo bajas de golpe a 0, cortamos el sonido al instante
                fuenteEfectos.Stop();
            }
        }
    }
}