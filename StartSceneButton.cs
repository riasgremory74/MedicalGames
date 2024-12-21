using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneButton : MonoBehaviour
{
    private TMP_Text buttonText; // TextMesh Pro text component
    private UnityEngine.UI.Button button; // Button component

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<UnityEngine.UI.Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on the GameObject! Please attach the Button component.");
            return;
        }

        // Get the TMP_Text component attached to the child of this GameObject
        buttonText = GetComponentInChildren<TMP_Text>();
        if (buttonText == null)
        {
            Debug.LogError("TMP_Text component not found in the children of this GameObject!");
            return;
        }

        // Add a listener to call the LoadScene method when the button is clicked
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        // Replace "SampleScene" with the name of your gameplay scene
        SceneManager.LoadScene("SelectLevel");
    }
}
