using UnityEngine;
using UnityEngine.UI;

public class GuardarMusica : MonoBehaviour
{
    private AudioSource miAudio;

    void Start()
    {
        miAudio = GetComponent<AudioSource>();
        // Al empezar, ponemos el volumen que estaba guardado
        float vol = PlayerPrefs.GetFloat("VolumenGuardado", 0.5f);
        if (miAudio != null) miAudio.volume = vol;
    }

    public void GuardarValorVolumen(float valor)
    {
        if (miAudio != null) miAudio.volume = valor;
        PlayerPrefs.SetFloat("VolumenGuardado", valor);
        PlayerPrefs.Save();
    }
}