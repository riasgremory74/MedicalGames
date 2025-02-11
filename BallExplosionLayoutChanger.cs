using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosionLayoutChanger : MonoBehaviour {

    public Renderer Playernd;
	// Use this for initialization
	void Start () {
        Playernd = gameObject.GetComponent<Renderer>();
        Playernd.material.color = new Color(PlayerPrefs.GetFloat("CurrenPlayerMatR"), PlayerPrefs.GetFloat("CurrenPlayerMatG"), PlayerPrefs.GetFloat("CurrenPlayerMatB"), 1);
    }
}
