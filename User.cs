using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class User : MonoBehaviour
{
    private static float userTotalScore;
    private static float usertotalCoinsCounter;
    public Text userTotalCoinsText;
    public Material PlayerMat;

    private void Start()
    {
        if (PlayerPrefs.HasKey("User") == false )
        {
            PlayerPrefs.SetInt("User", 1);
            PlayerPrefs.SetFloat("UserCoins", 0);
            PlayerPrefs.SetFloat("UserScore", 0);
            PlayerPrefs.SetString("CurrentPlayerMat", "Player\\PlayerMat");
            PlayerPrefs.SetString("CurrentObstacleMat", "Obstacle\\ObstacleMat");
            PlayerPrefs.SetString("CurrentGroundMat", "Ground\\GroundMat");
            PlayerMat = (Material)Resources.Load(PlayerPrefs.GetString("CurrentPlayerMat"), typeof(Material));
            PlayerPrefs.SetFloat("CurrenPlayerMatR", PlayerMat.color.r);
            PlayerPrefs.SetFloat("CurrenPlayerMatG", PlayerMat.color.g);
            PlayerPrefs.SetFloat("CurrenPlayerMatB", PlayerMat.color.b);
            PlayerPrefs.SetFloat("CurrentPlayerMatA", PlayerMat.color.a);
            PlayerPrefs.SetString("BUCurrentPlayerMat", PlayerPrefs.GetString("CurrentPlayerMat"));
            PlayerPrefs.SetString("BUCurrentObstacleMat", PlayerPrefs.GetString("CurrentObstacleMat"));
            PlayerPrefs.SetString("BUCurrentGroundMat", PlayerPrefs.GetString("CurrentGroundMat"));
            PlayerPrefs.SetFloat("BoostSpeedCounter", 0);
            PlayerPrefs.SetFloat("TransparentCounter", 0);
            PlayerPrefs.SetFloat("CoinsMagnetCounter", 0);
            PlayerPrefs.SetFloat("X2Counter", 0);
            PlayerPrefs.SetFloat("StartBoost2500Counter", 0);
            PlayerPrefs.SetFloat("StartBoost5000Counter", 0);
            PlayerPrefs.SetFloat("ShieldCounter", 0);
            PlayerPrefs.SetFloat("TiltSpeed", 1.5f);
            PlayerPrefs.SetFloat("ForceSpeed", 1.5f);
            PlayerPrefs.SetFloat("MovementMode", 2);
        }
        PlayerPrefs.SetString("CurrentPlayerMat", PlayerPrefs.GetString("BUCurrentPlayerMat"));
        PlayerPrefs.SetString("CurrentObstacleMat", PlayerPrefs.GetString("BUCurrentObstacleMat"));
        PlayerPrefs.SetString("CurrentGroundMat", PlayerPrefs.GetString("BUCurrentGroundMat"));
    }
    void Update()
    {
        usertotalCoinsCounter = PlayerPrefs.GetFloat("UserCoins");
        userTotalScore = PlayerPrefs.GetFloat("UserScore");
        userTotalCoinsText.text = usertotalCoinsCounter.ToString();
    }
    public static void AddThisGameScore(float value)
    {
        userTotalScore += value;
    }

    public static void AddThisGameCoins(float value)
    {
        usertotalCoinsCounter += value;
    }
}
