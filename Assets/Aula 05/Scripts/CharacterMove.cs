using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody rb;
    private Vector3 direction;

    void Update()
    {
        direction = Vector3.zero;

        HandleMovement();
        HandleCrouchAndRun();
        HandleJump();

    }

    void FixedUpdate()
    {
        direction = Vector3.ClampMagnitude(direction, 1f);
        rb.linearVelocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);
    }

    void HandleMovement()
    {
        if (Keyboard.current[Key.W].isPressed)
        {
            direction += transform.forward;
        }
        if (Keyboard.current[Key.S].isPressed)
        {
            direction += transform.forward * -1;
        }
        if (Keyboard.current[Key.D].isPressed)
        {
            direction += transform.right;
        }else if (Keyboard.current[Key.A].isPressed)
        {
            direction += transform.right * -1;
        }
    }

    void HandleCrouchAndRun()
    {
        if (Keyboard.current[Key.LeftCtrl].isPressed)
        {
            speed = 2.5f;
            rb.mass = 1.25f;
        }
        else
        {
            if (Keyboard.current[Key.LeftShift].isPressed)
            {
                speed = 7.5f;
                rb.mass = 0.75f;
            }
            else
            {
                speed = 5f;
                rb.mass = 1f;
            }
        }
    }

    void HandleJump()
    {
       if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            rb.AddForce(new Vector3(0f, 10f, 0f),ForceMode.Impulse);
        } 
    }
}
