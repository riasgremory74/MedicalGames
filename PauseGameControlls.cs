using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameControlls : MonoBehaviour
{
    public GameObject[] Panels;
    public GameObject[] Panels2;
    public GameObject CurrentlyActiveInHierarchy;
    public GameObject Player;
    public GameObject TimerObj;
    public Text TimerText;
    public Transform GamePanel;
    public Transform PausePanel;
    public Transform RestartPanel;
    public Transform LevelFinishedPanel;
    public Transform SettingsPanel;
    private bool active = true;
    private bool play;
    private double timer = 3;

    public void SetActive(bool value)
    {
        active = value;
    }
    void Update()
    {
        if (play == true)
        {
            Time.timeScale = 0;
            if (timer > 1)
            {
                timer -= 0.015;
            }
            if (timer > 1)
            {
                TimerText.text = timer.ToString("0");
                TimerText.color = Color.white;
            }

        }
        if(timer < 1 && play == true)
        {
            timer = 0;
            TimerText.text = "GO!";
            TimerText.color = Color.green;
            play = false;
            Time.timeScale = 1;
            Invoke("Disable", 0.35f);
        }
            

        if (Input.GetKeyDown(KeyCode.Escape) && active == true)
        {
            if (PausePanel.gameObject.activeInHierarchy == false)
            {
                Pause();
            }
            else if(PausePanel.gameObject.activeInHierarchy == true)
            {
                Play();
            }
        }
    }

    public void Disable()
    {
        TimerObj.SetActive(false);
    }
    

    public void RestartMenu()
    {
        RestartPanel.gameObject.SetActive(true);
        GamePanel.gameObject.SetActive(false);
    }

    public void Pause()
    {
        PausePanel.gameObject.SetActive(true);
        GamePanel.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    public void LevelFinished()
    {
        LevelFinishedPanel.gameObject.SetActive(true);
        GamePanel.gameObject.SetActive(true);
        
    }

    public void Play()
    {
        timer = 3;
        PausePanel.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(true);
        if (Player.transform.position.z > 0)
        {
            play = true;
            TimerObj.SetActive(true);
        }
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        string NextSceneName = SceneManager.GetSceneByBuildIndex(NextScene).name;
        SceneManager.LoadSceneAsync(NextScene);
    }

    public void Home()
    {
        Initiate.Fade("Main Menu");
        Debug.Log("G");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Initiate.Fade(SceneManager.GetActiveScene().name);
        Debug.Log("G");
        Time.timeScale = 1;
    }
    public void Levels()
    {
        Initiate.Fade("Levels Menu");
        Debug.Log("G");
        Time.timeScale = 1;
    }
    public void Settings()
    {
        SettingsPanel.gameObject.SetActive(true);
        for(int i = 0; i < Panels.Length; i++)
        {
            if(Panels[i].activeInHierarchy == true)
            {
                CurrentlyActiveInHierarchy = Panels2[i];
                CurrentlyActiveInHierarchy.SetActive(false);
            }
        }
    }
}
