using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool AllowInput = false; // Global flag for input control

    public static bool IsInputAllowed()
    {
        return AllowInput;
    }
}
