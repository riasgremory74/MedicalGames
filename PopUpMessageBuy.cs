using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessageBuy : MonoBehaviour {

    public GameObject PopUpPanel;
    public GameObject PopUpPanel2;
    public Text PopUpText;
    public Button PopUpButt;
    public bool Check;
    public int currentObject;
    public string CurrentObjectType;
    public float Price;

    public void SetPopUpPanel(string currentObjectType,int CurrentObject,float price)
    {
        if (PlayerPrefs.GetFloat("UserCoins") >= price)
        {
            CurrentObjectType = currentObjectType;
            currentObject = CurrentObject;
            Price = price;
            PopUpPanel.SetActive(true);
        }
        else
        {
            PopUpPanel2.SetActive(true);
        }
    }
    public void YesButton()
    {
        PlayerPrefs.SetFloat("UserCoins", (PlayerPrefs.GetFloat("UserCoins")) - Price);
        PlayerPrefs.SetInt((CurrentObjectType + "Mat" + currentObject), 1);
    }
}
