using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CoinsPanel;
    public GameObject SettingsPanel;
    public GameObject SettingsButt;
    public void Play()
    {
        Initiate.Fade("Levels Menu");
    }
    public void RateGame()
    {

    }
    public void Shop()
    {
        Initiate.Fade("ShopMenu");
    }
    public void Layouts()
    {
        Initiate.Fade("LayoutsMenu");
    }
    public void Stats()
    {

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