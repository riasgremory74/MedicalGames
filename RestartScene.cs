using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartScene : MonoBehaviour
{
    // Reference to the TextMeshPro button (or any other UI element)
    public TextMeshProUGUI restartButton;

    private void Start()
    {
        // Ensure the button is not null
        if (restartButton != null)
        {
            // Add a listener to the button click event
            restartButton.GetComponentInParent<UnityEngine.UI.Button>().onClick.AddListener(RestartCurrentScene);
        }
        else
        {
            Debug.LogWarning("Restart button is not assigned in the Inspector.");
        }
    }

    // Method to restart the current scene
    public void RestartCurrentScene()
    {
        // Get the active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
