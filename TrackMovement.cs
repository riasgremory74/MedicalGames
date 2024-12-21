using UnityEngine;
using TMPro;

public class TrackMovement : MonoBehaviour
{
    public GameObject myObject;
    public TextMeshProUGUI distanceText;
    private float totalDistanceTraveled = 0f;
    private Vector3 previousPosition;
    private float debugTimer = 0f;

    // Reference to the GameManager
    private GameManager gameManager;

    private void Start()
    {
        if (myObject != null)
        {
            previousPosition = myObject.transform.position;
        }

        if (distanceText != null)
        {
            distanceText.text = "Distance Traveled: 0";
        }

        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
    }

    private void Update()
    {
        if (myObject != null)
        {
            Vector3 currentPosition = myObject.transform.position;
            float distanceThisFrame = Mathf.Abs(currentPosition.x - previousPosition.x);
            totalDistanceTraveled += distanceThisFrame;
            previousPosition = currentPosition;

            debugTimer += Time.deltaTime;
            if (debugTimer >= 1f)
            {
                debugTimer = 0f;
                if (distanceText != null)
                {
                    distanceText.text = "Distance " + totalDistanceTraveled.ToString("F2");
                }
            }
        }
    }

    // Method to call when ending the game
    public void EndGame()
    {
        if (gameManager != null)
        {
            gameManager.EndGame(totalDistanceTraveled, 0); // Replace '0' with actual score if you have it
        }
    }
}
