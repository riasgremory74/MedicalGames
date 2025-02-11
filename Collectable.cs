using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static float objectValue=1;
    public static float rotateSpeed=20;
    void OnTriggerEnter(Collider ColliderInfo)
    {
        if(ColliderInfo.tag == "Player")
        {
            if (X2Mode.active == false)
            {
                Coins.SetgameCoinsCounter(objectValue);
                FindObjectOfType<CollectedAnim>().CoinAnim();
                Destroy(gameObject);
            }
            else if (X2Mode.active == true)
            {
                Coins.SetgameCoinsCounter(objectValue * 2);
                FindObjectOfType<CollectedAnim>().CoinAnim();
                Destroy(gameObject);
            }
        }
    }
}
