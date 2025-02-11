using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjType : MonoBehaviour {
    public Transform Objects3D;
    public bool keyboardkeys;
    public float ObjectsDistance;
    public static int currentobjectcounter = 0;
    public List<GameObject> objectsList;

    private float ScrollSpeed = 2;
    private float Objects3DMax;
    private float jumpingDistance;
    private float NumOfObjects;
    private float lastobject;
    private float currentobject;
    private float startingpoint;
    private float active;

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
        active = 0;
    }


    void FixedUpdate()
    {
        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////debug
        ////////--------------------------------------------------------
        ////////--------------------------------------------------------
        ////////androidkeys
        objectsList[currentobjectcounter].GetComponent<RotateObject>().enabled = true;

        for (int i = 0; i < objectsList.Count; i++)
        {
            if (i != currentobjectcounter)
            {
                objectsList[i].GetComponent<RotateObject>().enabled = false;
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
                else
                    active = 0;
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
                else
                    active = 0;
            }
        }
        if (active == 1)
        {
            GameObject.Find("LineGroups").GetComponent<SetActiveByList>().SetActive(currentobjectcounter);
            GameObject.Find("ButtonManagers").GetComponent<SetActiveByList>().SetActive(currentobjectcounter);
            GameObject.Find("ScrollingManagers").GetComponent<SetActiveByList>().SetActive(currentobjectcounter);
            if (currentobjectcounter == 0)
            {
                ScrollManagerPlayer.keyboardkeys = true;
                ScrollManagerObstacle.keyboardkeys = false;
                ScrollManagerGrounds.keyboardkeys = false;
            }
            else if (currentobjectcounter == 1)
            {
                ScrollManagerPlayer.keyboardkeys = false;
                ScrollManagerObstacle.keyboardkeys = true;
                ScrollManagerGrounds.keyboardkeys = false;
            }
            else if (currentobjectcounter == 2)
            {
                ScrollManagerPlayer.keyboardkeys = false;
                ScrollManagerObstacle.keyboardkeys = false;
                ScrollManagerGrounds.keyboardkeys = true;
            }
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
