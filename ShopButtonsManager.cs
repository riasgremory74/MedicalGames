using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonsManager : MonoBehaviour {

    public List<GameObject> RectList;
    public List<GameObject> BigRectList;
    public List<bool> active;
    public void Start()
    {
        for(int i = 0; i < RectList.Count; i++)
        {
            active.Add(false);
        }
    }

    public void Big(GameObject value)
    {
        for (int i = 0; i < RectList.Count; i++)
        {
            if (value.name != RectList[i].name)
            {
                if (active[i] == true)
                {
                    BigRectList[i].SetActive(false);
                    RectList[i].SetActive(true);
                }
            }
            else if (value.name == RectList[i].name)
            {
                BigRectList[i].SetActive(true);
                RectList[i].SetActive(false);
                active[i] = true;
            }
        }
    }
    public void Defualt(GameObject value)
    {
        for (int i = 0; i < BigRectList.Count; i++)
        {
            if(active[i] == true)
            {
                BigRectList[i].SetActive(false);
                RectList[i].SetActive(true);
                active[i] = false;
            }
        }
    }
}
