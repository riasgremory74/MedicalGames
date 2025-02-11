using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMeter : MonoBehaviour {

    public List<GameObject> Stage;

    public void Start()
    {
        for (int i = 0; i < Stage.Count; i++)
        {
            Stage[i].SetActive(false);
        }
    }
    public void Activate(float value)
    {
        for (int i = 0; i < value; i++)
        {
            Stage[i].SetActive(true);
        }
    }
}
