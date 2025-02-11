using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour
{
    public Text CoinsText;
    private static float gameCoinsCounter;
    void Awake()
    {
        gameCoinsCounter = 0;
    }

    public void Start()
    {
        RestartgameCoinsCounter();
    }

    void Update()
    {
        if (EndTrigger.gameEnded == false)
        {
            CoinsText.text = gameCoinsCounter.ToString("0");
        }
    }
    public static void SetgameCoinsCounter(float value)
    {
        gameCoinsCounter += value;
    }
    public static void RestartgameCoinsCounter()
    {
        gameCoinsCounter = 0;
    }
    public static float GetgameCoinsCounter()
    {   
        return Coins.gameCoinsCounter;
    }

}
