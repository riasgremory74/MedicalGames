using UnityEngine;

public class ShowCursorScript : MonoBehaviour
{
    void Start()
    {
        // Show the mouse cursor and unlock it from the center of the screen
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
