using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBoost5000 : MonoBehaviour
{

    private float BeforeSpeed;

    public GameObject Player;
    public GameObject Flash;
    public GameObject CountDownObj;
    public GameObject Butt2500;
    public GameObject Butt5000;
    public Text CountdownText;
    public List<GameObject> Obstacles;
    private float BoostForce = 1500;
    private float FirstPosition;
    public bool active;
    private bool BoostActive;
    private float delay;
    private float alpha = 1;
    private bool IsZero;
    private bool startBoost;


    private void Start()
    {
        active = false;
        startBoost = false;
    }
    public void StartBoost()
    {
        startBoost = true;
        StartOptionsManager.active = false;
        Butt5000.SetActive(false);
        Butt2500.SetActive(false);
        PlayerPrefs.SetFloat("BoostDistance5000", 5000f);
    }
    private void FixedUpdate()
    {
        if (BoostActive == true)
        {
            CountdownText.text = (PlayerPrefs.GetFloat("BoostDistance5000") - (Player.transform.position.z - FirstPosition)).ToString("0");
        }
        if (Player.transform.position.z < 0)
        {

        }
        else if (PlayerPrefs.GetFloat("StartBoost5000Counter") >= 1 && startBoost == true)
        {
            PlayerPrefs.SetFloat("StartBoost5000Counter", PlayerPrefs.GetFloat("StartBoost5000Counter") - 1);
            Flash.SetActive(true);
            FirstPosition = Player.transform.position.z;
            FindObjectOfType<LayoutChangerPlayer>().ChangePlayerMaterial("Player\\PlayerRedMat");
            BeforeSpeed = PlayerPrefs.GetFloat("FowardForce");
            PlayerPrefs.SetFloat("FowardForce", PlayerPrefs.GetFloat("FowardForce") + BoostForce);
            delay = 1.5f;
            active = true;
            BoostActive = true;
            CountDownObj.SetActive(true);
        }
        if (BoostActive == true)
        {
            foreach (GameObject Obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                if (Obstacles.Contains(Obstacle) == false)
                    Obstacles.Add(Obstacle);
            }
            foreach (GameObject Obstacle in Obstacles)
            {
                if (Obstacle != null)
                {
                    Obstacle.GetComponent<Collider>().enabled = false;
                }
            }
            if (Player.transform.position.x > 8f)
            {
                Player.transform.position = new Vector3(8, Player.transform.position.y, Player.transform.position.z);
            }
            if (Player.transform.position.x < -8f)
            {
                Player.transform.position = new Vector3(-8, Player.transform.position.y, Player.transform.position.z);
            }
        }
        if (PlayerCollider.StopAllModes == true)
        {
            Flash.SetActive(false);
            BoostActive = false;
            active = false;
            CountDownObj.SetActive(false);
        }
        if ((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("BoostDistance5000") && active == true)
        {
            Flash.SetActive(false);
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                PlayerPrefs.SetFloat("FowardForce", BeforeSpeed);
                Player.GetComponent<Renderer>().material.color = new Color(Player.GetComponent<Renderer>().material.color.r, Player.GetComponent<Renderer>().material.color.g, Player.GetComponent<Renderer>().material.color.b, alpha);
                CountDownObj.SetActive(false);
                #region LerpFunc
                if (alpha < 0)
                {
                    IsZero = true;
                }
                if (alpha > 0.58f)
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
                foreach (GameObject Obstacle in Obstacles)
                {
                    if (Obstacle != null)
                    {
                        Obstacle.GetComponent<Collider>().enabled = true;
                    }
                }
                FindObjectOfType<LayoutChangerPlayer>().ChangePlayerMaterial(PlayerPrefs.GetString("BUCurrentPlayerMat"));
                BoostActive = false;
            }
        }
    }
}
