using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedAnim : MonoBehaviour {
    public GameObject CoinImage;
    public int Counter;
    public List<GameObject> Coins;
    public List<GameObject> Coins1;
    public List<GameObject> Coins2;
    public List<float> Lerp;
    public List<bool> AnimActive;
    public List<RectTransform> CoinsRect;
    public static bool InfinityGame;
    public void Start()
    {
        Counter = 0;
        if (InfinityGame == false)
        {
            foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
            {
                if (Coins1.Contains(coin) == false)
                {
                    Coins1.Add(coin);
                    GameObject image = Instantiate(CoinImage, gameObject.transform);
                    Coins.Add(image);
                }
            }
            foreach (GameObject coin in Coins)
            {
                if (Coins2.Contains(coin) == false)
                {
                    Coins2.Add(coin);
                    AnimActive.Add(false);
                    Lerp.Add(0);
                    CoinsRect.Add(coin.GetComponent<RectTransform>());
                }
            }
        }
    }
    public void CoinAnim()
    {
        Coins[Counter].SetActive(true);
        AnimActive[Counter] = true;
        Counter++;
    }
    private void Update()
    {
        if (InfinityGame == true)
        {
            foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
            {
                if (Coins1.Contains(coin) == false)
                {
                    Coins1.Add(coin);
                    GameObject image = Instantiate(CoinImage, gameObject.transform);
                    Coins.Add(image);
                }
            }
            foreach (GameObject coin in Coins)
            {
                if (Coins2.Contains(coin) == false)
                {
                    Coins2.Add(coin);
                    AnimActive.Add(false);
                    Lerp.Add(0);
                    CoinsRect.Add(coin.GetComponent<RectTransform>());
                }
            }
        }

        for (int i =0; i <AnimActive.Count;i++)
        {
            if(AnimActive[i] ==true)
            {
                CoinsRect[i].localPosition = new Vector3(Mathf.Lerp(0, -200, Lerp[i]), Mathf.Lerp(0, 490, Lerp[i]), 0);
                CoinsRect[i].sizeDelta = new Vector2(Mathf.Lerp(35, 25, Lerp[i]), Mathf.Lerp(70, 50, Lerp[i]));
                Lerp[i] += 2f * Time.deltaTime;
                if (CoinsRect[i].localPosition == new Vector3(-200, 490, 0))
                {
                    Coins[i].SetActive(false);
                    AnimActive[i] = false;
                }
            }
        }
    }
}
