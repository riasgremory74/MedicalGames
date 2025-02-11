using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessageShop : MonoBehaviour
{

    public float Price;
    public string CurrentObjectType;
    public GameObject PopUpPanel;
    public GameObject PopUpPanel2;

    public void SetPopUpPanel(string currentObjectType, float price)
    {
        if (PlayerPrefs.GetFloat("UserCoins") >= price)
        {
            CurrentObjectType = currentObjectType;
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
        if (PlayerPrefs.GetFloat("UserCoins") >= Price)
        {
            PlayerPrefs.SetFloat(CurrentObjectType, PlayerPrefs.GetFloat(CurrentObjectType) + 1);
            PlayerPrefs.SetFloat("UserCoins", PlayerPrefs.GetFloat("UserCoins") - Price);
        }
    }
}
