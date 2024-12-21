using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    public AudioSource startupSound;
    public AudioSource idleSound;
    public AudioSource runningSound;
    public AudioSource gearShiftSound;  // Add a gear shift sound for realism

    public Rigidbody carRigidbody;

    private bool hasStarted = false;
    private float maxSpeedForCurrentGear = 10f;
    private float pitchBase = 0.8f;
    private float pitchMultiplier = 0.2f;
    private int currentGear = 1;
    private float maxPitch = 5f;
    private float gearShiftThreshold = 0.9f;  // Percentage of max pitch at which to shift gear

    void Start()
    {
        if (carRigidbody == null)
            carRigidbody = GetComponent<Rigidbody>();

        startupSound.Play();
        idleSound.Stop();
        runningSound.Stop();
        gearShiftSound.Stop();
    }

    void Update()
    {
        float speed = carRigidbody.linearVelocity.magnitude;

        // Play idle after startup
        if (!startupSound.isPlaying && !hasStarted)
        {
            hasStarted = true;
            idleSound.Play();
        }

        // Toggle between idle and running based on speed
        if (hasStarted)
        {
            if (speed > 0.5f)
            {
                if (!runningSound.isPlaying)
                {
                    idleSound.Stop();
                    runningSound.Play();
                }

                // Update pitch for running sound based on speed within current gear range
                float normalizedSpeed = speed / maxSpeedForCurrentGear;
                float targetPitch = Mathf.Lerp(pitchBase, pitchBase + pitchMultiplier, normalizedSpeed);
                runningSound.pitch = Mathf.Clamp(targetPitch, pitchBase, maxPitch);

                // Check if speed reaches threshold for gear shift
                if (normalizedSpeed >= gearShiftThreshold)
                {
                    ShiftGear();
                }
            }
            else
            {
                if (!idleSound.isPlaying)
                {
                    runningSound.Stop();
                    idleSound.Play();
                }
            }
        }
    }

    private void ShiftGear()
    {
        // Play gear shift sound and reset pitch for the next gear
        gearShiftSound.Play();

        // Increase the max speed for the current gear to simulate a gear shift
        currentGear++;
        maxSpeedForCurrentGear += 10f;

        // Reset pitch to give the effect of a new gear shift
        runningSound.pitch = pitchBase;
    }
}
