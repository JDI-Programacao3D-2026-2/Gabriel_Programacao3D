using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody rb;

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

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

        if (Keyboard.current[Key.LeftCtrl].isPressed)
        {
            speed = 2.5f;
        }
        else
        {
            if (Keyboard.current[Key.LeftShift].isPressed)
            {
                speed = 7.5f;
            }
            else
            {
                speed = 5f;
            }
        }


        direction = Vector3.ClampMagnitude(direction, 1f);
        rb.linearVelocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);
    }
}
