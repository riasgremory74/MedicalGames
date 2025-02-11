using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour {

    private float zPos;
    private float xPos;
    private float yLerp;
    private bool Increase;
    private bool Decrease;

    public void Start()
    {
        zPos = gameObject.transform.position.z;
        yLerp = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
        Decrease = true;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3(xPos, yLerp, zPos);
        if (yLerp <= 2)
        {
            Increase = true;
            Decrease = false;

        }
        else if(yLerp >= 8)
        {
            Decrease = true;
            Increase = false;
        }
        if(Increase == true)
        {
            yLerp += 4f * Time.deltaTime;
        }
        else if(Decrease == true)
        {
            yLerp -= 4f * Time.deltaTime;
        }

    }
}
