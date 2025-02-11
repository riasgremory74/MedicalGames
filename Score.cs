using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public static float thisGameScore;
    public static Score instance = null;
    private float EndDistance;
    public GameObject End;
    public Slider DistanceSlider;
    public GameObject Slider;

    void Start()
    {
        Slider.SetActive(false);
        thisGameScore = 0;
        EndDistance = End.transform.position.z / 100;
    }
    void Update()
    { 
        if (EndTrigger.gameEnded == false)
        {
            if (player.position.z > 0)
            {
                Slider.SetActive(true);
                scoreText.text = (player.position.z / EndDistance).ToString("0");
                scoreText.text += "%";
                DistanceSlider.value = player.position.z / EndDistance;
                if(player.position.z > End.transform.position.z)
                {
                    Slider.SetActive(false);
                }
            }
            else
            {
                Slider.SetActive(false);
            }
            thisGameScore = player.position.z;
        }
    }
}