using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextureManagerObstacle : MonoBehaviour {

    public PopUpMessageBuy PopUpInstance;
    public GameObject BuyPanel;
    public GameObject SelectPanel;
    public GameObject PricePanel;
    public GameObject SelectedPanel;
    public Text PriceText;
    public List<Textures> textureList;
    public float ListCounter;
    private int currentObject;



    [System.Serializable]
    public class Textures
    {
        public string TextureText;
        public int Price;
        public int Unlocked;
        public Material Mat;
    }
    private void Start()
    {
        FillList();
    }

    private void FillList()
    {
        for (int i = 0; i < textureList.Count; i++)
        {
            if (textureList[i].Price == 0 || textureList[i].TextureText == "1")
            {
                PlayerPrefs.SetInt("ObstacleMat" + i, 1);
            }
            textureList[i].Unlocked = PlayerPrefs.GetInt("ObstacleMat" + i);
            ListCounter++;
        }
        SaveAll();
    }

    public void FixedUpdate()
    {
        currentObject = ScrollManagerObstacle.currentobjectcounter;

    }
    public void Update()
    {
        LoadLayout();
    }


    private void SaveAll()
    {
        if (PlayerPrefs.HasKey("ObstacleMat1"))
        {
            return;
        }
        else
        {
            for (int i = 0; i < textureList.Count; i++)
            {
                PlayerPrefs.SetInt("ObstacleMat" + i, textureList[i].Unlocked);
            }
        }
    }
    void LoadLayout()
    {

        if (PlayerPrefs.GetInt("ObstacleMat" + currentObject) == 0)
        {
            BuyPanel.SetActive(true);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            PricePanel.SetActive(true);
            PriceText.text = textureList[currentObject].Price.ToString();

        }
        else if (PlayerPrefs.GetString("CurrentObstacleMat") == ("Obstacle\\" + textureList[currentObject].Mat.name))
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ObstacleMat" + currentObject) == 1)
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            SelectPanel.SetActive(true);

        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("Obstacle", currentObject, textureList[currentObject].Price);
    }
    public void Select()
    {
        string FullMatName;
        FullMatName = "Obstacle\\" + textureList[currentObject].Mat.name;
        PlayerPrefs.SetString("CurrentObstacleMat", FullMatName);
    }
}
