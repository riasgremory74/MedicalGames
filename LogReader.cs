using System;
using System.IO;
using System.Threading;
using TMPro;
using UnityEngine;

public class LiveLogReader : MonoBehaviour
{
  
    private FileStream fileStream;
    private Thread readThread;
    private volatile bool isRunning = true; // Volatile for thread safety
    private volatile float newYPosition = 0f; // Latest Y position, updated from joystick input
    private float speed = 0.0f; // Speed for automatic X-axis movement
    float inputSensitivity = 5f; // Increased sensitivity
    float x_Position = 0;

    void Start()
    {
       
    }

    void Update()
    {

        //Debug.Log($"Initial Y Position: {newYPosition}");
        GameObject myObject = GameObject.Find("MyObject");
        Vector3 p = myObject.transform.localPosition;
        float initialY = p.y;
        float moveInput = Input.GetAxis("Horizontal");  // Get the raw joystick or keyboard input
        //Debug.Log($"GetAxis Y Position: {moveInput}");
        moveInput = moveInput * inputSensitivity -3f;
        //Debug.Log($"Get the raw joystick or keyboard input Y Position: {initialY}");
        x_Position += speed * Time.deltaTime;
        if (myObject != null)
        {
            myObject.transform.position = new Vector3(x_Position, moveInput, myObject.transform.position.z);
        }
     }


    private void OnApplicationQuit()
    {
        // Clean up the thread and file stream
        isRunning = false;
        if (readThread != null && readThread.IsAlive)
        {
            readThread.Join();
        }
        if (fileStream != null)
        {
            fileStream.Close();
        }
    }
}
