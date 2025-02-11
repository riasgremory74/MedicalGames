using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public bool RandomRotation;
    public bool Z_Axis;

	void FixedUpdate ()
    {
        if (Z_Axis == true)
        {
            transform.Rotate(0, 0, 55 * Time.deltaTime);
        }
        else if (RandomRotation == true)
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
            transform.Rotate(40 * Time.deltaTime, 0, 0);
        }
    }
}
