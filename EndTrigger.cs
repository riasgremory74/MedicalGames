using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    

    public static bool gameEnded=false;
    public static bool GameEnded;

    private void Start()
    {
        gameEnded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        GameEnded = true;
        gameEnded = true;
        FindObjectOfType<Playermovement>().active = false;
        PlayerPrefs.SetFloat("UserCoins", PlayerPrefs.GetFloat("UserCoins") + Coins.GetgameCoinsCounter());
        PlayerPrefs.SetFloat("UserScore", PlayerPrefs.GetFloat("UserScore") + Score.thisGameScore);
        User.AddThisGameScore(Score.thisGameScore);
        SaveCurrentGameStats();
        FindObjectOfType<GameManager>().CompleteLevel();
    }

    public void SaveCurrentGameStats()
    {
        EndTrigger.gameEnded = false;
        PlayerPrefs.SetInt("Level" + (SceneManager.GetActiveScene().buildIndex - 2), 1);
        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_Coins") <= Coins.GetgameCoinsCounter())
        {
            PlayerPrefs.SetFloat((SceneManager.GetActiveScene().name + "_Coins"), Coins.GetgameCoinsCounter());
        }
    }
}
