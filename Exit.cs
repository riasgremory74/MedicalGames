using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToSceneScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the specified scene, in this case "Demo1"
            SceneManager.LoadScene("Demo1");
        }
    }
}
