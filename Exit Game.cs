using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void OnExitButtonClick()
    {
        // Load the "Level0" scene
        SceneManager.LoadScene("Level0");
    }
}
