using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayMenu : MonoBehaviour
{
    public GameObject CoinsPanel;
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject SettingsButt;
    public void LevelPack()
    {
        Initiate.Fade("Levels Menu");
    }
    public void InfinityGame()
    {

    }
    public void Back()
    {
        MainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
        SettingsButt.SetActive(false);
    }
    public void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            CoinsPanel.SetActive(true);
        }
    }
}