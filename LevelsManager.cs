using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public Text StarsText;
    private int StarsCounter;
    public GameObject levelButton;
    public Transform Spacer;
    public List<Level> LevelList;

    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public int Unlocked;
        public bool IsInteractable;
        public int Star1;
        public int Star2;
        public int Star3;
        public int StarsCounter;
    }
    
    void Start()
    {
        StarsCounter = 0;
        FillList();
    }

    void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject newbutton = Instantiate(levelButton) as GameObject;
            LevelButton button = newbutton.GetComponent<LevelButton>();
            button.LevelText.text = level.LevelText;
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                level.Unlocked = 1;
                level.IsInteractable = true;
            }
            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevels("Level" + button.LevelText.text));
            if (PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") != 0 && PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") > level.Star1 )
            {
                button.Star1.SetActive(true);
                level.StarsCounter = 1;
            }
            if (PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") != 0 && PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") >= level.Star2)
            {
                button.Star2.SetActive(true);
                level.StarsCounter = 2;
            }
            if (PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") != 0 && PlayerPrefs.GetFloat("Level" + button.LevelText.text + "_Coins") >= level.Star3)
            {
                button.Star3.SetActive(true);
                level.StarsCounter = 3;
            }
            newbutton.transform.SetParent(Spacer, false);
            StarsCounter += level.StarsCounter;
        }
        SaveAll();
    }
    void SaveAll()
    {
        if (PlayerPrefs.HasKey("Level1"))
        {
            return;
        }
        else {
            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject buttons in allButtons)
            {
                LevelButton button = buttons.GetComponent<LevelButton>();
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
            }
        }
    }
    void LoadLevels(string Value)
    {
        Initiate.Fade(Value);
    }
    public void Home()
    {
        Initiate.Fade("Main Menu");
    }
    public void Update()
    {
        StarsText.text = StarsCounter.ToString();
    }
}