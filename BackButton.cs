using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {

    public bool active;
    // Use this for initialization
    void Start()
    {
        
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            PlayerPrefs.SetString("LastScene", "Main Menu");
        }
        else if (SceneManager.GetActiveScene().name == "LayoutsMenu")
        {
            PlayerPrefs.SetString("LastScene", "Main Menu");
        }
        else if (SceneManager.GetActiveScene().name == "ShopMenu")
        {
            PlayerPrefs.SetString("ThisScene", "Main Menu");
        }
        else if(SceneManager.GetActiveScene().name == "Levels Menu")
        {
            PlayerPrefs.SetString("LastScene","Main Menu");
        }
    }

    void FixedUpdate()
    {   
        if (Input.GetKey(KeyCode.Escape) && PlayerPrefs.GetInt("BackButtonCounter") != 3)
        {
            if (SceneManager.GetActiveScene().name == "LayoutsMenu")
            {
                PlayerPrefs.SetString("BUCurrentPlayerMat", PlayerPrefs.GetString("CurrentPlayerMat"));
                PlayerPrefs.SetString("BUCurrentObstacleMat", PlayerPrefs.GetString("CurrentObstacleMat"));
                PlayerPrefs.SetString("BUCurrentGroundMat", PlayerPrefs.GetString("CurrentGroundMat"));
            }
            PlayerPrefs.SetInt("BackButtonCounter", PlayerPrefs.GetInt("BackButtonCounter") - 1);
            Initiate.Fade(PlayerPrefs.GetString("LastScene")); 

        }
    }
    
    public void Back()
    {
        if (SceneManager.GetActiveScene().name == "LayoutsMenu")
        {
            PlayerPrefs.SetString("BUCurrentPlayerMat", PlayerPrefs.GetString("CurrentPlayerMat"));
            PlayerPrefs.SetString("BUCurrentObstacleMat", PlayerPrefs.GetString("CurrentObstacleMat"));
            PlayerPrefs.SetString("BUCurrentGroundMat", PlayerPrefs.GetString("CurrentGroundMat"));
        }
        PlayerPrefs.SetInt("BackButtonCounter", PlayerPrefs.GetInt("BackButtonCounter") - 1);
        Initiate.Fade(PlayerPrefs.GetString("LastScene"));
    }
}
