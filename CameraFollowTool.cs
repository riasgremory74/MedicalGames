using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollowTool : MonoBehaviour {

    public GameObject TimerObj;
    public Transform player;
    private float lerp;
    private float Distance;
    private float CurrentDistance;
    public static float timer;
    public Text timerText;
    public float delay;
    public bool Follow;
    
    private void Start()
    {
        Follow = true;
        Distance = -player.position.z / 3;
        CurrentDistance = -Distance * 3;
        timer = 3;
        lerp = transform.rotation.eulerAngles.x;
    }
    void FixedUpdate()
    {
            if (player.position.z < 0)
            {
                if (player.position.z > CurrentDistance)
                {
                    timer -= 1;
                    CurrentDistance += Distance;
                }
                if (timer == 0)
                {
                    timerText.text = "GO!";
                    timerText.color = Color.green;
                }
                else
                    timerText.text = timer.ToString();
            }
            else if (transform.position.z > 0)
            {
                TimerObj.SetActive(false);
            }   
    }




    private void Update()
    {
        if (Follow == true)
        {
            {
                if (delay > 0)
                {
                    if (lerp > 0)
                        lerp -= 0.15f;
                    delay -= Time.deltaTime;
                    transform.position = player.position;
                    if (Time.timeScale == 1)
                        transform.rotation = Quaternion.Euler(lerp, 0, 0);
                }
                else
                {
                    transform.position = player.position;
                }
            }
        }
    }
}
 