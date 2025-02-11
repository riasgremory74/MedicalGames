using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetActiveByList : MonoBehaviour {

    public List<GameObject> Objects3D;

    public void SetActive(int value)
    {
        if (Objects3D.ElementAtOrDefault(value) != null)
        {
            for (int i = 0; i < Objects3D.Count; i++)
            {
                Objects3D[i].SetActive(false);
            }
            Objects3D[value].SetActive(true);
        }
    }
}
