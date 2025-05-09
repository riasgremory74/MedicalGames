using UnityEngine;
using UnityEngine.UI;  // Include the UI namespace
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public WaveProperties waveProperties; // Reference to the ScriptableObject

    // References to your sliders
    public Slider speedSlider;
    public Slider amplitudeSlider;
    public Slider frequencySlider;

    private void Start()
    {
        // Initialize sliders with current values
        speedSlider.value = waveProperties.speed;
        amplitudeSlider.value = waveProperties.amplitude;
        frequencySlider.value = waveProperties.frequency;

        // Add listeners to the sliders
        speedSlider.onValueChanged.AddListener(delegate { UpdateWaveProperties(); });
        amplitudeSlider.onValueChanged.AddListener(delegate { UpdateWaveProperties(); });
        frequencySlider.onValueChanged.AddListener(delegate { UpdateWaveProperties(); });
    }

    public void UpdateWaveProperties()
    {
        SetWaveProperties(speedSlider.value, amplitudeSlider.value, frequencySlider.value);
    }

    public void SetWaveProperties(float speed, float amplitude, float frequency)
    {
        // Store the slider values using PlayerPrefs
        PlayerPrefs.SetFloat("WaveSpeed", speed);
        PlayerPrefs.SetFloat("WaveAmplitude", amplitude);
        PlayerPrefs.SetFloat("WaveFrequency", frequency);

        PlayerPrefs.Save();  // Save the preferences
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
