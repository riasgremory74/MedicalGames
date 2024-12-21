using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign this in the Inspector
    private float timeElapsed = 0f;

    void Start()
    {
        // Check if timerText is assigned
        if (timerText == null)
        {
            // Instead of warning, you can handle it silently or set a default behavior
            return; // Exit if timerText is not assigned
        }

        // Initialize the timer display
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Update the timer every frame
        timeElapsed += Time.deltaTime;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Ensure timerText is assigned before attempting to update it
        if (timerText != null)
        {
            // Format the time to display minutes and seconds
            float minutes = Mathf.FloorToInt(timeElapsed / 60);
            float seconds = Mathf.FloorToInt(timeElapsed % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
