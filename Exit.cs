using UnityEngine;
using TMPro;

public class ExitButtonScript : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component (optional, to modify text dynamically)
    public TextMeshProUGUI buttonText;

    // Function to quit the application
    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Optional: Update the button text (if needed)
    public void SetButtonText(string text)
    {
        if (buttonText != null)
        {
            buttonText.text = text;
        }
    }
}
