using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BoostSpeed : MonoBehaviour {
    private float BeforeSpeed;

    public GameObject Player;
    public GameObject Flash;
    public GameObject CountDownObj;
    public Text CountdownText;
    public List<GameObject> Obstacles;
    private float FirstPosition;
    public static bool active;
    public static bool BoostActive;
    private float delay;
    private float alpha = 1;
    private bool IsZero;

    private void Start()
    {
        PlayerPrefs.SetFloat("FowardForce", 5000);
        active = false;
        Player = GameObject.Find("Player");
        Flash = GameObject.Find("BoostSpeed_Lightning");

    }
    void OnTriggerEnter()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Flash.SetActive(true);
        FirstPosition = Player.transform.position.z;
        FindObjectOfType<LayoutChangerPlayer>().ChangePlayerMaterial("Player\\PlayerRedMat");
        BeforeSpeed = PlayerPrefs.GetFloat("FowardForce");
        PlayerPrefs.SetFloat("FowardForce", 0);
        delay = 1.5f;
        active = true;
        CountDownObj.SetActive(true);
        BoostActive = true;
    }
    private void FixedUpdate()
    {
        if (active == true)
        {
            CountdownText.text = (PlayerPrefs.GetFloat("BoostSpeedDistance") - (Player.transform.position.z - FirstPosition)).ToString("0");
        }
        if (BoostActive == true)
        {
            //\\........................................ after creating upgrade system ................................//
            //\\............................................ if user has upgrade 3 ...................................//
            //\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\//
            foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                if (Obstacles.Contains(obstacle) == false)
                    Obstacles.Add(obstacle);
            }
            foreach (GameObject obstacle in Obstacles)
            {
                if (obstacle != null)
                {
                    obstacle.GetComponent<BoxCollider>().enabled = false;
                }
            }
            if (Player.transform.position.x > 9f)
            {
                Player.transform.position = new Vector3(9f, Player.transform.position.y, Player.transform.position.z);
            }
            if (Player.transform.position.x < -9f)
            {
                Player.transform.position = new Vector3(-9f, Player.transform.position.y, Player.transform.position.z);
            }
            if (Player.transform.position.z > 0)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, Player.transform.position.z + PlayerPrefs.GetFloat("BoostDistance"), 0.011f));
            }
        }
        if(PlayerCollider.StopAllModes == true)
        {
            Flash.SetActive(false);
            BoostActive = false;
            active = false;
        }
        if ((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("BoostSpeedDistance") && active == true)     
        {
            Flash.SetActive(false);
            if (delay > 0)
            {
                CountDownObj.SetActive(false);
                delay -= Time.deltaTime;
                PlayerPrefs.SetFloat("FowardForce", BeforeSpeed);
                Player.GetComponent<Renderer>().material.color = new Color(Player.GetComponent<Renderer>().material.color.r, Player.GetComponent<Renderer>().material.color.g, Player.GetComponent<Renderer>().material.color.b, alpha);
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
            }
            else
            {
                // ........................................ after creating upgrade system ................................//
                // ........................................... if user has upgrade 3 ....................................//
                //\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\
                foreach (GameObject Obstacle in Obstacles)
                {
                    if (Obstacle != null)
                    {
                        Obstacle.GetComponent<BoxCollider>().enabled = true;
                    }
                }
                FindObjectOfType<LayoutChangerPlayer>().ChangePlayerMaterial(PlayerPrefs.GetString("BUCurrentPlayerMat"));
                BoostActive = false;
                active = false;
            }
        }
    }
}
