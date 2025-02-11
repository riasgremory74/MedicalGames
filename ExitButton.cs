using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    // This function will be called when the Exit button is clicked
    public void ExitGame()
    {
        // Logs the message in the editor
        Debug.Log("Exiting game...");

        // Exits the application (will work in the built game)
        Application.Quit();

        // If you're running in the Unity editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
