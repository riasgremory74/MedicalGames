using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LayoutsCurrentObj : MonoBehaviour {

    public List<GameObject> Objects3D;          
    public int counter;

    public void Makebigger(int value)
    {
        if (Objects3D.ElementAtOrDefault(value) != null)
        {
            for(int i = 0; i < Objects3D.Count;i++)
            {
                Objects3D[value].SetActive(false);
            }
            Objects3D[value].SetActive(true);
        }
    }
}
