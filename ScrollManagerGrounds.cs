using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManagerGrounds : MonoBehaviour {

    public Transform Objects3D;
    private float ScrollSpeed = 2;
    private float Objects3DMax;
    public static bool keyboardkeys;
    public float ObjectsDistance;
    private float jumpingDistance;
    private float NumOfObjects;
    private float lastobject;
    private float currentobject;
    public static int currentobjectcounter = 0;
    private float startingpoint;
    private float active;
    public static bool start;
    public List<GameObject> objectsList;
    public void Start()
    {
        currentobjectcounter = 0;
        Objects3DMax = Objects3D.transform.position.x;
        NumOfObjects = objectsList.Count;
        ObjectsDistance = (Objects3D.transform.position.x * 2) / NumOfObjects;
        jumpingDistance = (Objects3D.transform.position.x * 2) / (NumOfObjects - 1);
        currentobject = Objects3D.position.x - ObjectsDistance;
        lastobject = Objects3D.position.x;
        startingpoint = Objects3D.position.x;
        active = 1;
        start = false;
    }


    void FixedUpdate()
    {
        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////debug
        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////androidkeys
        if (keyboardkeys == true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchdeltaposition = Input.GetTouch(0).deltaPosition;
                Objects3D.transform.Translate(((touchdeltaposition.x * ScrollSpeed * 9.7f) / 5000), 0, 0, Space.World);
            }
        }
        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////keyboardkeys
        if (keyboardkeys == true)
        {
            Objects3D.transform.Translate(Input.GetAxis("Horizontal") * ScrollSpeed / 9.65f, 0, 0, Space.World);
        }

        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////Limiter and Calculation
        if (Objects3D.transform.position.x > Objects3DMax)
        {
            Objects3D.transform.position = new Vector3(Objects3DMax, Objects3D.transform.position.y, Objects3D.transform.position.z);
        }

        if (Objects3D.transform.position.x < -Objects3DMax)
        {
            Objects3D.transform.position = new Vector3(-Objects3DMax, Objects3D.transform.position.y, Objects3D.transform.position.z);
        }


        ////////switch indexer and Make Bigger
        ////////-------------------------------------------------
        ////////-------------------------------------------------

        if (Objects3D.position.x < currentobject)
        {
            if (Objects3D.position.x < Objects3DMax - ObjectsDistance)
            {
                lastobject = currentobject;
                currentobject -= ObjectsDistance;
                if (currentobjectcounter < objectsList.Count - 1)
                    currentobjectcounter += 1;
                if (Objects3DMax > (-Objects3DMax + ObjectsDistance))
                    active = 1;
            }
        }
        if (Objects3D.position.x > lastobject)
        {
            if ((Objects3D.position.x > -Objects3DMax + ObjectsDistance))
            {
                currentobject = lastobject;
                lastobject += ObjectsDistance;
                if (currentobjectcounter > 0)
                    currentobjectcounter -= 1;
                if (Objects3D.position.x > (-Objects3DMax + ObjectsDistance))
                    active = 1;
            }
        }
        if (active == 1)
        {
            GameObject.Find("GroundsGroup").GetComponent<SetActiveByList>().SetActive(currentobjectcounter);
        }
    }


    public void ScrollRight()
    {
        if (Objects3D.position.x > -Objects3DMax)
            Objects3D.transform.position = new Vector3(Objects3D.transform.position.x - jumpingDistance, Objects3D.transform.position.y, Objects3D.transform.position.z);
    }
    public void ScrollLeft()
    {
        if (Objects3D.position.x < Objects3DMax)
            Objects3D.transform.position = new Vector3(Objects3D.transform.position.x + jumpingDistance, Objects3D.transform.position.y, Objects3D.transform.position.z);
    }
}
