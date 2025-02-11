using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureManagerGrounds : MonoBehaviour {

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
                PlayerPrefs.SetInt("GroundMat" + i, 1);
            }
            textureList[i].Unlocked = PlayerPrefs.GetInt("GroundMat" + i);
            ListCounter++;
        }
        SaveAll();
    }

    public void FixedUpdate()
    {
        currentObject = ScrollManagerGrounds.currentobjectcounter;

    }
    public void Update()
    {

        LoadLayout();
    }


    private void SaveAll()
    {
        if (PlayerPrefs.HasKey("GroundMat1"))
        {
            return;
        }
        else
        {
            for (int i = 0; i < textureList.Count; i++)
            {
                PlayerPrefs.SetInt("GroundMat" + i, textureList[i].Unlocked);
            }
        }
    }
    void LoadLayout()
    {

        if (PlayerPrefs.GetInt("GroundMat" + currentObject) == 0)
        {
            BuyPanel.SetActive(true);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            PricePanel.SetActive(true);
            PriceText.text = textureList[currentObject].Price.ToString();

        }
        else if (PlayerPrefs.GetString("CurrentGroundMat") == ("Ground\\" + textureList[currentObject].Mat.name))
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectPanel.SetActive(false);
            SelectedPanel.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("GroundMat" + currentObject) == 1)
        {
            PricePanel.SetActive(false);
            BuyPanel.SetActive(false);
            SelectedPanel.SetActive(false);
            SelectPanel.SetActive(true);

        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("Ground", currentObject, textureList[currentObject].Price);
    }
    public void Select()
    {
        string FullMatName;
        FullMatName = "Ground\\" + textureList[currentObject].Mat.name;
        PlayerPrefs.SetString("CurrentGroundMat", FullMatName);
    }
}   
