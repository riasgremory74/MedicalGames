using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSpeedManager : MonoBehaviour {
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
        Meter1.Activate(PlayerPrefs.GetFloat("BoostSpeedCounter"));
        Meter2.Activate(PlayerPrefs.GetFloat("BoostSpeedCounter"));
        if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 0)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 0);
            Price = Price0;
        }
        else if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 1)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 250f);
            Price = Price1;
        }
        else if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 2)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 500f);
            Price = Price2;
        }
        else if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 3)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 1000);
            Price = Price3;
        }
        else if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 4)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 1750f);
            Price = Price4;
        }
        else if (PlayerPrefs.GetFloat("BoostSpeedCounter") == 5)
        {
            PlayerPrefs.SetFloat("BoostSpeedDistance", 2500f);
            Price = Price5;
        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("BoostSpeedCounter", Price);
    }
}
