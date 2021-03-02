using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float JumpForce = 10f;
    public Rigidbody2D rb;

    public Transform feet;
    public LayerMask groundLayers;

    float movex;

   

    private void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();

        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movex * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }


    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, JumpForce);

        rb.velocity = movement;

    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }
}
