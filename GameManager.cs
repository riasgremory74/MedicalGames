using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading
using TMPro; // For TextMeshPro UI

public class GameManager : MonoBehaviour
{
    public static float totalDistanceTraveled = 0f; // To store traveled distance across scenes
    public static int score = 0; // Assuming you have a score system

    public void EndGame(float distanceTraveled, int currentScore)
    {
        // Store the traveled distance and score globally
        totalDistanceTraveled = distanceTraveled;
        score = currentScore;

        // Load the next scene (result screen)
        SceneManager.LoadScene("ResultScene");
    }
}
