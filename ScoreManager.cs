using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton instance

    public TMP_Text scoreText;  // Reference to the TextMeshPro Text component
    private int score;
    public static int finalScore;  // Static variable to store the score across scenes
    private void Awake()
    {
        // Ensure there is only one instance of ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        finalScore = score;  // Update static finalScore each time score changes
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
