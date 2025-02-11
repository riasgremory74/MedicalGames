using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOptionsManager : MonoBehaviour {

    public GameObject Player;
    public GameObject StartBoost2500;
    public GameObject StartBoost5000;
    public static bool active;

    private void Start()
    {
        active = true;
    }

    private void Update()
    {
        if (active == false)
        {
            StartBoost2500.SetActive(false);
            StartBoost5000.SetActive(false);
        }
        if (Player.transform.position.z < 0)
        {
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
        if (PlayerPrefs.GetFloat("StartBoost2500Counter") >= 1 && active == true)
        {
            StartBoost2500.SetActive(true);
        }
        else
            StartBoost2500.SetActive(false);
        if (PlayerPrefs.GetFloat("StartBoost5000Counter") >= 1)
        {
            StartBoost5000.SetActive(true);
        }
        else
            StartBoost5000.SetActive(false);
    }
}
