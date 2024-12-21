using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Drag your player GameObject here in the Inspector
    public Vector3 offset;    // Adjust this offset to set camera position relative to the player

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
