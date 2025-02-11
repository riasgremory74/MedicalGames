using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutChangerObstacle : MonoBehaviour {

    public Renderer Obstaclend;
    public string MatName;

    void Start()
    {
        Obstaclend = gameObject.GetComponent<Renderer>();
        Obstaclend.material = (Material)Resources.Load(PlayerPrefs.GetString("CurrentObstacleMat"), typeof(Material));
    }

    void Update()
    {
    }
    public void ChangePlayerColor(Color value)
    {
        Obstaclend.material.color = value;
    }
    public void ChangePlayerMaterial(string value)
    {
        string FullMatName = "Player\\" + value;
        if (value.Contains("Player\\"))
        {
            Obstaclend.material = (Material)Resources.Load(value, typeof(Material));
        }
        else
            Obstaclend.material = (Material)Resources.Load(FullMatName, typeof(Material));
    }
}
