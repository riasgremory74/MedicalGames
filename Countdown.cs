using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Reference to the TextMeshPro component
    public float countdownDuration = 3f; // Countdown duration in seconds

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float timer = countdownDuration;
        InputManager.AllowInput = false; // Disable input at the start

        while (timer > 0)
        {
            countdownText.text = Mathf.CeilToInt(timer).ToString(); // Display countdown
            yield return new WaitForSeconds(1f);
            timer--;
        }

        countdownText.text = "Go!"; // Display "Go!"
        yield return new WaitForSeconds(1f);

        countdownText.text = ""; // Clear the countdown text
        InputManager.AllowInput = true; // Enable input
    }
}
