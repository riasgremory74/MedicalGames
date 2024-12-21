using UnityEngine;

public class AutomaticGearSystem : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public float[] gearSpeedLimits; // Define speed limits for each gear (e.g., [20, 40, 60, 80, 100])
    public float[] gearAccelerations; // Define acceleration for each gear (e.g., [5, 4, 3, 2, 1])

    private int currentGear = 0;
    private float currentSpeed;

    void Start()
    {
        if (gearSpeedLimits.Length != gearAccelerations.Length)
        {
            Debug.LogError("Gear speed limits and accelerations arrays must have the same length!");
        }
    }

    void Update()
    {
        currentSpeed = carRigidbody.linearVelocity.magnitude * 3.6f; // Convert to km/h for display purposes

        // Shift gears based on speed
        ShiftGears();

        // Apply acceleration based on the current gear
        float acceleration = gearAccelerations[currentGear];
        Vector3 force = transform.forward * acceleration;
        carRigidbody.AddForce(force, ForceMode.Acceleration);
    }

    void ShiftGears()
    {
        // Shift up if we exceed the current gear's speed limit
        if (currentGear < gearSpeedLimits.Length - 1 && currentSpeed >= gearSpeedLimits[currentGear])
        {
            currentGear++;
        }
        // Shift down if we fall below the previous gear's speed limit (add some margin to prevent quick up/down shifts)
        else if (currentGear > 0 && currentSpeed < gearSpeedLimits[currentGear - 1] - 5f)
        {
            currentGear--;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Speed: " + currentSpeed.ToString("F1") + " km/h");
        GUI.Label(new Rect(10, 30, 200, 20), "Gear: " + (currentGear + 1));
    }
}
