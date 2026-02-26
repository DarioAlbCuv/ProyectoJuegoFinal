/* Autor: Dario Alberto Cuevas
 * Descripción: Transforma el valor lineal del Slider de la UI en una escala 
 * logarítmica (Mathf.Log10) para una atenuación acústica realista.
 * Fecha de creación: 12/02/2026
 * Última modificación: 22/02/2026
*/
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
            // Leemos el volumen de la memoria al abrir el menú 
            float volGuardado = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
            miSlider.value = volGuardado;
            fuenteEfectos.volume = volGuardado * volGuardado;
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

            // 3. Si la barra está abajo del todo (casi 0), no reproducimos nada
            if (valor > 0.01f)
            {
                // Si no está sonando ya, lo reproducimos
                if (!fuenteEfectos.isPlaying && sonidoSalto != null)
                {
                    fuenteEfectos.clip = sonidoSalto;
                    fuenteEfectos.Play();
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