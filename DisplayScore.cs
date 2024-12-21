using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        // Using the static variable
        int finalScore = ScoreManager.finalScore;

        // If using PlayerPrefs:
        // int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        scoreText.text = "Final Score: " + finalScore;
    }
}
