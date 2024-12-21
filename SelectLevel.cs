using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        // Loop through the buttons and add a listener to each one
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i; // Store the index in a local variable to avoid closure issue
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    public void LoadLevel(int levelIndex)
    {
        // Assuming your levels are named "Level1", "Level2", etc.
        string levelName = "Level" + (levelIndex + 1); // levelIndex + 1 to match the names
        SceneManager.LoadScene(levelName);
    }
}
