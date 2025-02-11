using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public GameObject PopUpPanel;
    public GameObject CoinsPanel;
    public GameObject SettingsPanel;
    public GameObject MainMenuSettingsButt;
    public Toggle ForceMode_Toggle;
    public Toggle TiltMode_Toggle;
    public Button DeleteAll_Toggle;
    public GameObject ForceSlider;
    public GameObject TiltSlider;
    public GameObject ForceText;
    public GameObject TiltText;
    public GameObject forceReset;
    public GameObject tiltReset;
    public float forceSpeed;
    public float tiltSpeed;


    private void Start()
    {
        forceSpeed = PlayerPrefs.GetInt("ForceSpeed");
        tiltSpeed = PlayerPrefs.GetFloat("TiltSpeed");
        if (PlayerPrefs.GetInt("MovementMode") == 2)
        {
            ForceMode_Toggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("MovementMode") == 1)
        {
            TiltMode_Toggle.isOn = true;
        }
    }


    public void RotationLock(bool value)
    {
        if(value == true)
        {
            PlayerPrefs.SetInt("Orientation", 0);
            
        }
        else if(value == false)
        {
            PlayerPrefs.SetInt("Orientation", 1);
        }
    }
    public void Mute(bool value)
    {
        if(value == true)
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
        else if(value == false)
        {
            PlayerPrefs.SetInt("Mute", 1);
        }
    }

    public void ForceMode(bool value)
    {
        if (value == true)
        {
            PlayerPrefs.SetInt("MovementMode", 2);
        }
    }

    public void TiltMode(bool value)
    {
        if (value == true)
        {
            PlayerPrefs.SetInt("MovementMode", 1);
        }
    }

    public void ForceSpeed(float value)
    {
        PlayerPrefs.SetFloat("ForceSpeed",value);
        value =  PlayerPrefs.GetFloat("ForceSpeed");
    }

    public void TiltSpeed(float value)
    {
        PlayerPrefs.SetFloat("TiltSpeed", value);
        value = PlayerPrefs.GetFloat("TiltSpeed");
    }

    public void ForceSpeedText(string value)
    {
        PlayerPrefs.SetFloat("ForceSpeed", float.Parse(value));
    }

    public void TiltSpeedText(string value)
    {
        PlayerPrefs.SetFloat("TiltSpeed", float.Parse(value));
    }

    public void ForceReset()
    {
        PlayerPrefs.SetFloat("ForceSpeed", 1.5f);
    }
    public void TiltReset()
    {
        PlayerPrefs.SetFloat("TiltSpeed", 1.5f);
    }

    public void DeleteAllButt()
    {
        PopUpPanel.SetActive(true);
    }
    public void HidePopUpPanel()
    {
        PopUpPanel.SetActive(false);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Initiate.Fade("Main Menu");
    }



    public void Get100Coins(bool value)
    {
        if(value == true)
            PlayerPrefs.SetFloat("UserCoins", (PlayerPrefs.GetFloat("UserCoins")) + 100);
    }

    public void Back()
    {
        SettingsPanel.SetActive(false);
        
        if (CoinsPanel != null)
            CoinsPanel.SetActive(true);
        if(MainMenuSettingsButt != null)
            MainMenuSettingsButt.SetActive(true);
    }




    public void Update()
    {
        ForceText.GetComponent<InputField>().text = (PlayerPrefs.GetFloat("ForceSpeed")).ToString();
        TiltText.GetComponent<InputField>().text = PlayerPrefs.GetFloat("TiltSpeed").ToString();
        ForceSlider.GetComponent<Slider>().value = (PlayerPrefs.GetFloat("ForceSpeed"));
        TiltSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("TiltSpeed");
        PlayerPrefs.SetString("LastScene", "Main Menu");

        if(ForceMode_Toggle.isOn == true)
        {
            ForceSlider.SetActive(true);
            TiltSlider.SetActive(false);
            ForceText.SetActive(true);
            TiltText.SetActive(false);
            forceReset.SetActive(true);
            tiltReset.SetActive(false);
        }
        if (TiltMode_Toggle.isOn == true)
        {
            ForceSlider.SetActive(false);
            TiltSlider.SetActive(true);
            ForceText.SetActive(false);
            TiltText.SetActive(true);
            forceReset.SetActive(false);
            tiltReset.SetActive(true);
        }
    }
}
