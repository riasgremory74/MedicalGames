using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    private float sidewaysForce = 55;
    public Rigidbody rd;
    public GameObject CameraFollowTool;
    public Vector3 direction;

    public static bool stopgame;
    public bool active;
    public bool keyboardinput= true;
    public bool keyboardInput1 = true;
    public bool androidinput = true;
    public float positiveX;
    public float negativeX;
    public float forceDivider = 5;
    public float lerp;

    private void Start()
    {   
        active = true;
        stopgame = false;

        PlayerPrefs.SetFloat("ForwardForce", 3500);
    }
    void FixedUpdate()
    {
        if (active == true)
        {
            rd.AddForce(0, 0, PlayerPrefs.GetFloat("ForwardForce") * Time.deltaTime,ForceMode.Acceleration);
        }
        if (keyboardInput1 == true)
        {
            positiveX = Mathf.Lerp(1, 0.1f, rd.linearVelocity.x / forceDivider);
            negativeX = Mathf.Lerp(-1, -0.1f, -rd.linearVelocity.x / forceDivider);

            if (Input.GetKey(KeyCode.D))
            {
                rd.AddForce(Vector3.right * sidewaysForce * positiveX * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rd.AddForce(Vector3.right * sidewaysForce * negativeX * Time.deltaTime, ForceMode.Acceleration);

            }
        }
        if (keyboardinput == true && transform.position.z > -25)
        {
            if (Input.GetKey("d"))
            {
                if (active == true)
                {
                    rd.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
            if (Input.GetKey("a"))
            {
                if (active == true)
                {
                    rd.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
        }
        if (transform.position.y < -10)
        {
            if (EndTrigger.GameEnded == false)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
    public void Update()
    {
        if (androidinput == true && transform.position.z > -25)
        {
            if (PlayerPrefs.GetInt("MovementMode") == 1)
            {
                positiveX = Mathf.Lerp(1, 0.1f, rd.linearVelocity.x / forceDivider);
                negativeX = Mathf.Lerp(-1, -0.1f, -rd.linearVelocity.x / forceDivider);
                if(Input.acceleration.x > 0)
                {
                    rd.AddForce(Input.acceleration.x * Time.deltaTime * PlayerPrefs.GetFloat("TiltSpeed") * 100 * positiveX, 0, 0, ForceMode.VelocityChange);
                }
                else if(Input.acceleration.x < 0)
                {
                    rd.AddForce(Input.acceleration.x * Time.deltaTime * PlayerPrefs.GetFloat("TiltSpeed") * 100 * -negativeX, 0, 0, ForceMode.VelocityChange);
                }
            }
            if (PlayerPrefs.GetInt("MovementMode") == 2)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && active == true)
                {
                    positiveX = Mathf.Lerp(1, 0.1f, rd.linearVelocity.x / forceDivider);
                    negativeX = Mathf.Lerp(-1, -0.1f, -rd.linearVelocity.x / forceDivider);
                    // Get movement of the finger since last frame
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    // Move object across XY plane
                    if(touchDeltaPosition.x > 0)
                    {
                        rd.AddForce(touchDeltaPosition.x * PlayerPrefs.GetFloat("ForceSpeed") * positiveX * 2 *  Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    }
                    else if (touchDeltaPosition.x < 0)
                    {
                        rd.AddForce(touchDeltaPosition.x * PlayerPrefs.GetFloat("ForceSpeed") * -negativeX * 2 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    }
                }
            }
        }
    }
}
