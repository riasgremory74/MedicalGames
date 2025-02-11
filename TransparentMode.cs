using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TransparentMode : MonoBehaviour {

    public GameObject Player;
    public GameObject CountDownObj;
    public Text CountdownText;
    public List<GameObject> Obstacles;
    private float FirstPosition;
    private float delay;
    private bool active;
    private float alpha = 1;
    private bool IsZero;


    void OnTriggerEnter()
    {
        PlayerPrefs.SetFloat("TransparentDistance", 50f);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        FirstPosition = Player.transform.position.z;
        //Player.GetComponent<Renderer>().material.color
        FindObjectOfType<LayoutChangerPlayer>().ChangePlayerMaterial("Player\\TransparentMat");
        delay = 2f;
        active = true;
        CountDownObj.SetActive(true);
    }
     
    void FixedUpdate()
    {
        if (active == true)
        {
            Debug.Log(FirstPosition);
            CountdownText.text = (PlayerPrefs.GetFloat("TransparentDistance") - (Player.transform.position.z - FirstPosition)).ToString("0");
        }
        if ((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("TransparentDistance") && active == true)
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
            if (delay > 0)
            {
                CountDownObj.SetActive(false);
                delay -= Time.deltaTime;
                Player.GetComponent<Renderer>().material.color = new Color(Player.GetComponent<Renderer>().material.color.r, Player.GetComponent<Renderer>().material.color.g, Player.GetComponent<Renderer>().material.color.b, alpha);
#region LerpFunc
                if (alpha <  0)
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
                active = false;
            }
        }
    }
}
