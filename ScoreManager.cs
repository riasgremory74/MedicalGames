using UnityEngine;
using TMPro; // Import the TextMesh Pro namespace

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TextMesh Pro component

    private int currentScore = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
