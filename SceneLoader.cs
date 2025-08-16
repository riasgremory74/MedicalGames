using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadVakhmiatScene()
    {
        SceneManager.LoadScene("Vakhmiat");  // Load the scene named "Vakhmiat"
    }
}
