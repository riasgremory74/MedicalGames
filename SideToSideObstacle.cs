using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideObstacle : MonoBehaviour {

    private float zPos;
    private float yPos;
    private float xLerp;
    private bool Increase;
    private bool Decrease;
    public float yMin;
    public float yMax;

    public void Start()
    {
        zPos = gameObject.transform.position.z;
        xLerp = gameObject.transform.position.x;
        yPos = gameObject.transform.position.y;
        Increase = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(xLerp, yPos, zPos);
        if (xLerp <= yMin)
        {
            Increase = true;
            Decrease = false;
        }
        else if (xLerp >= yMax)
        {
            Decrease = true;
            Increase = false;
        }
        if (Increase == true)
        {
            xLerp += 4.5f * Time.deltaTime;
        }
        else if (Decrease == true)
        {
            xLerp -= 4.5f * Time.deltaTime;
        }

    }
}
