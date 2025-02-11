using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public GameObject BallExplode;
    public static bool StopAllModes;
    public static bool shield;
    public static float delay;

    private void Start()
    {
        StopAllModes = false;
        shield = false;
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (shield == false)
        {
            if (collisioninfo.collider.tag == "Obstacle")
            {
                StopAllModes = true;
                Destroy();
            }
        }
    }
    private void OnTriggerEnter(Collider Collisioninfo)
    {
        if (shield == true)
        {
            if (Collisioninfo.tag == "Obstacle")
            {
                Shield.stop = true;
            }
        }
    }

    void Destroy()
    {
        gameObject.SetActive(false);
        BallExplode.SetActive(true);
        FindObjectOfType<GameManager>().EndGame();
    }
}
