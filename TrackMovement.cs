using UnityEngine;
using TMPro;

public class TrackMovement : MonoBehaviour
{
    public GameObject myObject; // Object to track
    public TextMeshProUGUI distanceText; // UI Text to display distance
    private float totalDistanceTraveledX = 0f; // Total distance traveled on X-axis
    private float previousXPosition; // Previous X position of the object
    private float debugTimer = 0f;

    private void Start()
    {
        if (myObject != null)
        {
            previousXPosition = myObject.transform.position.x; // Initialize with starting X position
        }

        if (distanceText != null)
        {
            distanceText.text = "Distance on X: 0";
        }
    }

    private void Update()
    {
        if (myObject != null)
        {
            float currentXPosition = myObject.transform.position.x;
            float distanceThisFrame = Mathf.Abs(currentXPosition - previousXPosition);
            totalDistanceTraveledX += distanceThisFrame; // Add X-axis movement to total
            previousXPosition = currentXPosition; // Update the previous X position

            debugTimer += Time.deltaTime;
            if (debugTimer >= 1f) // Update the UI every second
            {
                debugTimer = 0f;
                if (distanceText != null)
                {
                    distanceText.text = "Distance on X: " + totalDistanceTraveledX.ToString("F2");
                }
            }

            // Debug log for tracking
            Debug.Log($"Current X: {currentXPosition}, Previous X: {previousXPosition}, Distance This Frame: {distanceThisFrame}, Total Distance: {totalDistanceTraveledX}");
        }
    }
}
