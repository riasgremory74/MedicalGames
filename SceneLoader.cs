using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    // This function will be called on button click to load the scene
    public void LoadVakhmiatScene()
    {
        SceneManager.LoadScene("Vakhmiat");
    }
}
