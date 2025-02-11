using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    private float restartDelay = 0.2f;
    private float LevelEndedDelay = 2f;
    public GameObject completeLevelUI;
    public static float StartGameDelay = 0f;

    public void Start()
    {
        restartDelay = 0.5f;
        LevelEndedDelay = 2f;
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("LevelEnded", LevelEndedDelay);
    }

    public void LevelEnded()
    {
        EndTrigger.gameEnded = false;
        FindObjectOfType<PauseGameControlls>().LevelFinished();
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        Coins.RestartgameCoinsCounter();
        FindObjectOfType<CameraFollowTool>().Follow = false;
        FindObjectOfType<PauseGameControlls>().RestartMenu();
    }
}
