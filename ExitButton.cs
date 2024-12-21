using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitButton : MonoBehaviour
{
    private Button exitButton;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        exitButton = GetComponent<Button>();

        // Add a listener to call the ExitGame method when the button is clicked
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        // Quit the application
        Application.Quit();

        // If running in the editor, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
