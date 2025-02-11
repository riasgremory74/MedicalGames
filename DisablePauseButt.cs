using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePauseButt : MonoBehaviour {
    public GameObject PauseButt;
    public GameObject Player;

    void OnTriggerEnter()
    {
        PauseButt.SetActive(false);
        FindObjectOfType<PauseGameControlls>().SetActive(false);
    }
}
