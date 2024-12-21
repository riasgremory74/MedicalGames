using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    // This function will be called when the restart button is clicked
    public void OnRestartButtonClick()
    {
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
