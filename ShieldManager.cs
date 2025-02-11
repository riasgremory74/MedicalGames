using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldManager : MonoBehaviour {
    public PopUpMessageShop PopUpInstance;
    public Text PriceText1;
    public Text PriceText2;
    public Text AmountText1;
    public Text AmountText2;
    public float Price = 200;

    public void Update()
    {
        PriceText1.text = Price.ToString();
        PriceText2.text = Price.ToString();
        AmountText1.text = PlayerPrefs.GetFloat("ShieldCounter").ToString();
        AmountText2.text = PlayerPrefs.GetFloat("ShieldCounter").ToString();
    }

    public void Buy()
    {
        PopUpInstance.SetPopUpPanel("ShieldCounter", Price);
    }
}
