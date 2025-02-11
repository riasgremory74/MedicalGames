using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // Assign these in the Inspector
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Display the stored distance and score from GameManager
        if (distanceText != null)
        {
            distanceText.text = "Total Distance Traveled: " + GameManager.totalDistanceTraveled.ToString("F2");
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.score;
        }
    }
}
