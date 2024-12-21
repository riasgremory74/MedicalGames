using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveProperties : MonoBehaviour
{
    public Slider speedSlider;
    public Slider amplitudeSlider;
    public Slider frequencySlider;

    public float amplitude { get; set; } // Public setter to allow external modification
    public float frequency { get; set; } // Same for frequency
    public float speed { get; set; } // And speed

    void Start()
    {
        // Initialize the sliders and attach listeners
        UpdateProperties();
        speedSlider.onValueChanged.AddListener(delegate { UpdateProperties(); });
        amplitudeSlider.onValueChanged.AddListener(delegate { UpdateProperties(); });
        frequencySlider.onValueChanged.AddListener(delegate { UpdateProperties(); });
    }

    void UpdateProperties()
    {
        speed = speedSlider.value;
        amplitude = amplitudeSlider.value;
        frequency = frequencySlider.value;

        // Debugging: Print current values to the console
        Debug.Log($"Speed: {speed}, Amplitude: {amplitude}, Frequency: {frequency}");
    }
    //void UpdateSpeed(float value)
    //{
    //    speed = value;
    //}

    //void UpdateAmplitude(float value)
    //{
    //    amplitude = value;
    //}

    //void UpdateFrequency(float value)
    //{
    //    frequency = value;
    //}
}
