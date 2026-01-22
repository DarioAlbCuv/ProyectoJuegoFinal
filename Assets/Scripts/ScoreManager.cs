using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshProUGUI scoreText;    
    public TextMeshProUGUI highScoreText; 

    private float topScore = 0f;
    private int currentHighScore;

    void Start()
    {
        // 1. Cargamos el récord al iniciar
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        // 2. Lo mostramos en el HUD desde el principio
        if (highScoreText != null)
        {
            highScoreText.text = "RÉCORD: " + currentHighScore.ToString();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > topScore)
        {
            topScore = playerTransform.position.y;
            int scoreActual = (int)topScore;

            scoreText.text = "PUNTOS: " + scoreActual.ToString();

            // 3. Si superamos el récord actual
            if (scoreActual > currentHighScore)
            {
                currentHighScore = scoreActual;

                // Actualizamos el texto del récord en tiempo real
                if (highScoreText != null)
                {
                    highScoreText.text = "RÉCORD: " + currentHighScore.ToString();
                }

                // Guardamos en memoria permanente
                PlayerPrefs.SetInt("HighScore", currentHighScore);
            }
        }
    }
}