using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] float characterSpeed, jumpSpeed;
    Rigidbody2D rigidbody;
    float inputSensitivity = 3.0f;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(0f, 8f);
     

    }
    
    public void CharacterSpeed()
    {
        rigidbody.AddForce(Vector2.up * jumpSpeed);
    }

    float AdjustByPlayer(float x)
    {

        float moveInput = Input.GetAxis("Horizontal");  // Get the raw joystick or keyboard input

        Debug.Log($"Joystick Move Input (Horizontal) : {x}");

        
        moveInput *= inputSensitivity;
        gameObject.transform.Translate(moveInput * characterSpeed * Time.deltaTime, 0, 0);

        return moveInput;

    }
    public void Move(float target, float arenaExtents)
    {

        // Apply movement
        Vector3 p = transform.localPosition;

        float initialX = p.x;

        p.x = AdjustByPlayer(p.x);


        // p.x = Mathf.Clamp(p.x + direction.x * speed * Time.fixedDeltaTime, -arenaExtents, arenaExtents);
        transform.localPosition = p;
       
        // Debugging output
        Debug.Log($"Paddle Position after Move: {p.x}");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterControl>().CharacterSpeed();            
        }
    }
}
 