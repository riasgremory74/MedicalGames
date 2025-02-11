using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NabotObstacle : MonoBehaviour
{

    private float yRot;
    private float xLerp;
    private float zRot;
    private bool Increase;
    private bool Decrease;
    private bool side;

    public void Start()
    {
        side = false;
        zRot = 0;
        yRot = 0;
        xLerp = gameObject.transform.localEulerAngles.x;
        if (xLerp == 0)
        {
            xLerp = -180;
            Increase = true;
        }
        if (xLerp < 181 && xLerp > 89)
            side = true;
        if (xLerp > -181 && xLerp < -89)
            side = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(side == true)
        {
            gameObject.transform.localEulerAngles = new Vector3(xLerp, yRot, zRot);
            if (xLerp <= 90)
            {
                Increase = true;
                Decrease = false;
            }
            else if (xLerp >= 180)
            {
                Decrease = true;
                Increase = false;
            }
            if (Increase == true)
            {
                xLerp += 45f * Time.deltaTime;
            }
            else if (Decrease == true)
            {
                xLerp -= 45f * Time.deltaTime;
            }
        }
        if (side == false)
        {
            gameObject.transform.localEulerAngles = new Vector3(xLerp, yRot, zRot);
            
            if(xLerp > 180)
            {
                xLerp -= 360;
            }
            if (xLerp <= -180)
            {
                Increase = true;
                Decrease = false;
            }
            if (xLerp >= -90)
            {
                Decrease = true;
                Increase = false;
            }
            if (Increase == true)
            {
                xLerp += 45f * Time.deltaTime;
            }
            else if (Decrease == true)
            {
                xLerp -= 45f * Time.deltaTime;
            }

        }
    }
}