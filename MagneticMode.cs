using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagneticMode : MonoBehaviour
{
    public GameObject Player;
    public GameObject Flash;
    public GameObject CountDownObj;
    public Text CountdownText;
    public List<GameObject> Coins;
    private bool active;
    private float FirstPosition;
    private void Start()
    {
        active = false;
        foreach (GameObject Coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Coins.Add(Coin);
        }
    }

    void OnTriggerEnter()
    {
        active = true;
        FirstPosition = Player.transform.position.z;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Flash.SetActive(true);
        CountDownObj.SetActive(true);
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            CountdownText.text = (PlayerPrefs.GetFloat("CoinsMagnetDistance") - (Player.transform.position.z - FirstPosition)).ToString("0");
        }
        if (active == true)
        {
            foreach (GameObject Coin in Coins)
            {
                if (Coin != null)
                {
                    if (Player.transform.position.z > Coin.transform.position.z)
                    {
                        Coin.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
                    }
                }
            }
        }
        if (PlayerCollider.StopAllModes == true)
        {
            CountDownObj.SetActive(false);
            Flash.SetActive(false);
            active = false;
        }
        if((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("CoinsMagnetDistance"))
        {
            CountDownObj.SetActive(false);
            active = false;
            Flash.SetActive(false);
        }
    }
}
