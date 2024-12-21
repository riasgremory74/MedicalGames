using UnityEngine;
using TMPro;

public class TotalMovementTracker : MonoBehaviour
{
    public Transform character;  // Reference to the character
    public TextMeshProUGUI movementText;  // Reference to the TextMeshPro text

    private float lastX;  // Last recorded X position
    private float totalMovement;  // Total movement made

    void Start()
    {
        if (character != null)
        {
            // Initialize the last recorded position
            lastX = character.position.x;
        }
    }

    void Update()
    {
        if (character != null && movementText != null)
        {
            // Calculate the movement made since the last frame
            float movementSinceLastFrame = Mathf.Abs(character.position.x - lastX);

            // Add the movement to the total movement
            totalMovement += movementSinceLastFrame;

            // Update the last recorded position
            lastX = character.position.x;

            // Display the total movement on the TextMeshPro text
            movementText.text = "Total Movement: " + totalMovement.ToString("F2") + " units";
        }
    }
}
