using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsMagnetManager : MonoBehaviour {
    public PopUpMessageShop PopUpInstance;
    public Text PriceText1;
    public Text PriceText2;
    public UpgradeMeter Meter1;
    public UpgradeMeter Meter2;
    private float Price;
    public float Price0;
    public float Price1;
    public float Price2;
    public float Price3;
    public float Price4;
    public float Price5;
    public void Update()
    {
        PriceText1.text = Price.ToString();
        PriceText2.text = Price.ToString();
        Meter1.Activate(PlayerPrefs.GetFloat("CoinsMagnetCounter"));
        Meter2.Activate(PlayerPrefs.GetFloat("CoinsMagnetCounter"));
        if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 0)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 0);
            Price = Price0;
        }
        else if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 1)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 250f);
            Price = Price1;
        }
        else if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 2)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 500f);
            Price = Price2;
        }
        else if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 3)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 1000);
            Price = Price3;
        }
        else if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 4)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 1750f);
            Price = Price4;
        }
        else if (PlayerPrefs.GetFloat("CoinsMagnetCounter") == 5)
        {
            PlayerPrefs.SetFloat("CoinsMagnetDistance", 2500f);
            Price = Price5;
        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("CoinsMagnetCounter", Price);
    }
}
