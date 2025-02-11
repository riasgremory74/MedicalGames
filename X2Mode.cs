using UnityEngine.UI;
using UnityEngine;

public class X2Mode : MonoBehaviour
{
    public GameObject Player;
    public GameObject CountDownObj;
    public Text CountdownText;
    public static bool active;
    private float FirstPosition;


    private void OnTriggerEnter()
    {
        active = true;
        CountDownObj.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        FirstPosition = Player.transform.position.z;
    }

    private void FixedUpdate()
    {
        if(active == true)
        {
            CountdownText.text = (PlayerPrefs.GetFloat("2XDistance") - (Player.transform.position.z - FirstPosition)).ToString("0");
        }
        if ((Player.transform.position.z - FirstPosition) > PlayerPrefs.GetFloat("2XDistance"))
        {
            active = false;
            CountDownObj.SetActive(false);
        }
    }
}
