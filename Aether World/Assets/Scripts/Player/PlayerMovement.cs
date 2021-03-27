using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    public Transform feet;
    public LayerMask groundLayers;

    public int jumpMax = 0;
    public int jumpCount = 0;

    private bool IsFacingRight = true;

    float movex;

    private void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");

        if(movex > 0)
        {
            IsFacingRight = true;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movex < 0)
        {
            IsFacingRight = false;
            //transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && ((jumpCount < jumpMax) || IsGrounded()))
        {
            Jump();
        }

        

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movex * movementSpeed, rb.velocity.y);

        rb.velocity = movement;

        IsGrounded();
    }


    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        if (jumpCount < jumpMax)
        {
            rb.velocity = movement;
            jumpCount++;
            //Debug.Log("Jumped?");
        }
        else
        {
            Debug.Log("Already used " + jumpMax + " jumps");
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null && rb.velocity.y == 0)
        {
            jumpCount = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
