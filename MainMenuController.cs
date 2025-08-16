using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject difficultyPanel;
    public GameObject levelPanel;
    public Button playButton;
    public Button exitButton;

    [Header("Level Buttons")]
    public Button vakhmiatButton;
    public Button bagheFarbodButton;
    public Button level3Button; // Optional

    [Header("Difficulty Buttons")]
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    [Header("Navigation Buttons")]
    public Button backButton;


    private string selectedSceneName = "";

    void Start()
    {
        difficultyPanel.SetActive(true);
        levelPanel.SetActive(false);
        playButton.gameObject.SetActive(false);

        // Assign difficulty buttons with difficulty index (0 = Easy, 1 = Medium, 2 = Hard)
        easyButton.onClick.AddListener(() => OnDifficultySelected(0));
        mediumButton.onClick.AddListener(() => OnDifficultySelected(1));
        hardButton.onClick.AddListener(() => OnDifficultySelected(2));

        ApplyButtonStyle(exitButton, new Color(1f, 0.3f, 0.3f));
        ApplyButtonStyle(playButton, new Color(0.4f, 1f, 0.4f));
        ApplyButtonStyle(easyButton, new Color(0.43f, 1f, 0.7f));
        ApplyButtonStyle(mediumButton, new Color(1f, 0.91f, 0.4f));
        ApplyButtonStyle(hardButton, new Color(1f, 0.42f, 0.42f));
        ApplyButtonStyle(vakhmiatButton, new Color(0.4f, 0.7f, 1f));
        ApplyButtonStyle(bagheFarbodButton, new Color(0.4f, 0.7f, 1f));

        if (level3Button != null)
        {
            level3Button.interactable = true;
            var level3Text = level3Button.GetComponentInChildren<TMP_Text>();
            if (level3Text) level3Text.text = "Level3";
            ApplyButtonStyle(level3Button, new Color(0.4f, 0.7f, 1f));
            level3Button.onClick.AddListener(() => SelectLevel("SharifAbad"));
        }

        vakhmiatButton.onClick.AddListener(() => SelectLevel("Vakhmiat"));
        bagheFarbodButton.onClick.AddListener(() => SelectLevel("BagheFarbod"));
        backButton.onClick.AddListener(OnBackButtonPressed);
        backButton.gameObject.SetActive(false);
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    void OnDifficultySelected(int index)
    {
        if (InputSensitivityManager.instance != null)
        {
            InputSensitivityManager.instance.SetDifficulty(index);
            Debug.Log("Difficulty set to: " + ((InputSensitivityManager.Difficulty)index).ToString());
        }

        difficultyPanel.SetActive(false);
        levelPanel.SetActive(true);
        backButton.gameObject.SetActive(true); // Show back button when in level panel
    }
    void OnBackButtonPressed()
    {
        levelPanel.SetActive(false);
        difficultyPanel.SetActive(true);
        backButton.gameObject.SetActive(false); // Hide it again
        playButton.gameObject.SetActive(false); // Hide Play button when going back
        selectedSceneName = ""; // Reset selected scene
    }

    void ApplyButtonStyle(Button button, Color baseColor)
    {
        var colors = button.colors;
        colors.normalColor = baseColor;
        colors.highlightedColor = baseColor * 1.2f;
        colors.pressedColor = baseColor * 0.8f;
        button.colors = colors;

        var text = button.GetComponentInChildren<TMP_Text>();
        if (text != null)
        {
            text.color = Color.white;
            text.fontSize = 28;
            text.fontStyle = FontStyles.Bold;
        }
    }

    void SelectLevel(string sceneName)
    {
        selectedSceneName = sceneName;
        levelPanel.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    void PlayGame()
    {
        if (!string.IsNullOrEmpty(selectedSceneName))
        {
            SceneManager.LoadScene(selectedSceneName);
        }
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
