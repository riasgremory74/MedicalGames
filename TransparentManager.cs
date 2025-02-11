using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentManager : MonoBehaviour {
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
        Meter1.Activate(PlayerPrefs.GetFloat("TransparentCounter"));
        Meter2.Activate(PlayerPrefs.GetFloat("TransparentCounter"));
        if (PlayerPrefs.GetFloat("TransparentCounter") == 0)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 0);
            Price = Price0;
        }
        else if (PlayerPrefs.GetFloat("TransparentCounter") == 1)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 250f);
            Price = Price1;
        }
        else if (PlayerPrefs.GetFloat("TransparentCounter") == 2)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 500f);
            Price = Price2;
        }
        else if (PlayerPrefs.GetFloat("TransparentCounter") == 3)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 1000);
            Price = Price3;
        }
        else if (PlayerPrefs.GetFloat("TransparentCounter") == 4)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 1750f);
            Price = Price4;
        }
        else if (PlayerPrefs.GetFloat("TransparentCounter") == 5)
        {
            PlayerPrefs.SetFloat("TransparentDistance", 2500f);
            Price = Price5;
        }
    }
    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("TransparentCounter", Price);
    }
}
