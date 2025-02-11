using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureManagerPlayer: MonoBehaviour {

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
        for(int i = 0; i < textureList.Count;i++)
        {
            if (textureList[i].Price == 0 || textureList[i].TextureText == "1")
            {
                PlayerPrefs.SetInt("PlayerMat" + i, 1);
            }
            textureList[i].Unlocked = PlayerPrefs.GetInt("PlayerMat" + i);
                ListCounter++;
        }
        SaveAll();
    }

    public void FixedUpdate()
    {
        currentObject = ScrollManagerPlayer.currentobjectcounter;
        
    }
    public void Update()
    {
        LoadLayout();
    }


    private void SaveAll()
    {
        if (PlayerPrefs.HasKey("PlayerMat1"))
        {
            return;
        }
        else
        {
            for (int i = 0; i < textureList.Count; i++)
            {
                PlayerPrefs.SetInt("PlayerMat" + i, textureList[i].Unlocked);
            }
        }
    }
    void LoadLayout()
    {
        if (PlayerPrefs.GetInt("PlayerMat" + currentObject) == 0)
        {
            BuyPanel.SetActive(true);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            PricePanel.SetActive(true);
            PriceText.text = textureList[currentObject].Price.ToString();

        }
        else if (PlayerPrefs.GetString("CurrentPlayerMat") == ("Player\\" + textureList[currentObject].Mat.name))
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PlayerMat" + currentObject) == 1)
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            SelectPanel.SetActive(true);
        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("Player",currentObject,textureList[currentObject].Price);
    }
    public void Select()
    {
        string FullMatName;
        FullMatName = "Player\\" + textureList[currentObject].Mat.name;
        PlayerPrefs.SetString("CurrentPlayerMat", FullMatName);
        PlayerPrefs.SetFloat("CurrenPlayerMatR",textureList[currentObject].Mat.color.r);
        PlayerPrefs.SetFloat("CurrenPlayerMatG", textureList[currentObject].Mat.color.g);
        PlayerPrefs.SetFloat("CurrenPlayerMatB", textureList[currentObject].Mat.color.b);
    }
}
