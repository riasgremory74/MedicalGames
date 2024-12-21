using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for scene loading

public class ScoreObject : MonoBehaviour
{
    public int scoreValue = 1;        // Points added when the object is collected
    public bool isFinalObject = false; // Set this to true for the final score object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure the player has the "Player" tag
        {
            ScoreManager.instance.AddScore(scoreValue);  // Add to score
            Destroy(gameObject);  // Destroy the score object

            if (isFinalObject)  // Check if this is the final object
            {
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Results");  // Replace "NextScene" with the name of your target scene
    }
}
