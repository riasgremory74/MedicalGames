using UnityEngine;

public class LayoutChangerPlayer : MonoBehaviour {

    public Renderer Playernd;
    public string MatName;

    void Start ()
    {

        PlayerPrefs.SetString("CurrentObstacleMat", PlayerPrefs.GetString("BUCurrentObstacleMat"));
        PlayerPrefs.SetString("CurrentGroundMat", PlayerPrefs.GetString("BUCurrentGroundMat"));
        PlayerPrefs.SetString("CurrentPlayerMat", PlayerPrefs.GetString("BUCurrentPlayerMat"));
        Playernd = gameObject.GetComponent<Renderer>();
        Playernd.material = (Material)Resources.Load(PlayerPrefs.GetString("CurrentPlayerMat"), typeof(Material));
    }
	
    public void ChangePlayerColor(Color value)
    {
        Playernd.material.color = value;
    }
    public void ChangePlayerMaterial(string value)
    {
        string FullMatName = "Player\\" + value;
        if (value.Contains("Player\\"))
        {
            Playernd.material = (Material)Resources.Load(value, typeof(Material));
        }
        else
            Playernd.material = (Material)Resources.Load(FullMatName, typeof(Material));
    }
}
