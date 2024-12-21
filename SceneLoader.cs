using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using UnityEngine.UI; // Required for button functionality

public class SceneLoader : MonoBehaviour
{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene"); // Load SampleScene
    }

    public void LoadLevelMedium()
    {
        SceneManager.LoadScene("LevelMedium"); // Load LevelMedium
    }

    public void LoadLevelHard()
    {
        SceneManager.LoadScene("LevelHard"); // Load LevelHard
    }
}
