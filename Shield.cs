using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour {


    public GameObject Player;
    public GameObject shield;
    public List<GameObject> Obstacles;
    public Text AmountText;
    private float FirstPosition;
    private float delay;
    private float alpha = 1;
    private bool IsZero;
    public static bool ShieldActive;
    public static bool StartShield;
    public static bool stop;
    public GameObject ShieldButt;


    private void Start()
    {
        PlayerPrefs.SetFloat("ShieldDistance", 100f);
        StartShield = false;
        stop = false;
    }
    public void ShieldStart()
    {
        if(StartShield == false && PlayerPrefs.GetFloat("ShieldCounter") >= 1)
        {
            StartShield = true;
            PlayerPrefs.SetFloat("ShieldCounter", PlayerPrefs.GetFloat("ShieldCounter") - 1);
        }
    }
    void FixedUpdate()
    {
        if (PlayerPrefs.GetFloat("ShieldCounter") < 1)
        {
            ShieldButt.SetActive(false);
        }
        else
        {
            ShieldButt.SetActive(true);
        }
        AmountText.text = PlayerPrefs.GetFloat("ShieldCounter").ToString("0");
        if (Player.transform.position.z < 0)
        {
            
        }
        else if (StartShield == true && stop == false)
        {
            delay = 1.5f;
            alpha = 1;
            FirstPosition = Player.transform.position.z;
            shield.SetActive(true);
            ShieldActive = true;
        }
        if (ShieldActive == true)
        {
            PlayerCollider.shield = true;
            StartShield = false;
            foreach (GameObject Obstacle in Obstacles)
            {
                if (Obstacle != null)
                {
                    Obstacle.GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        foreach (GameObject Obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (Obstacles.Contains(Obstacle) == false)
                Obstacles.Add(Obstacle);
        }
        if((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("ShieldDistance"))
        {
            stop = true;
        }
        if (stop == true)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                shield.GetComponent<Renderer>().material.color = new Color(shield.GetComponent<Renderer>().material.color.r, shield.GetComponent<Renderer>().material.color.g, shield.GetComponent<Renderer>().material.color.b, alpha);
                #region LerpFunc
                if (alpha < 0)
                {
                    IsZero = true;
                }
                if (alpha > 1f)
                {
                    IsZero = false;
                }
                if (IsZero == true)
                {
                    alpha += 0.05f;
                }
                if (IsZero == false)
                {
                    alpha -= 0.05f;
                }
                #endregion
            }
            else
            {
                shield.SetActive(false);
                ShieldActive = false;
                PlayerCollider.shield = false;
                stop = false;
            }
        }
        if (ShieldActive == false)
        {
            foreach (GameObject Obstacle in Obstacles)
            {
                if (Obstacle != null)
                {
                    Obstacle.GetComponent<Collider>().isTrigger = false;
                }
            }
        }
    }
}
