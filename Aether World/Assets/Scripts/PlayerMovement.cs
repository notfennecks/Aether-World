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

    public string currentStance;
    public string stance;
    public SpriteRenderer spriteRender;

    [Header("Stance 1 Variables")]
    public float stanceFastMovementSpeed;
    public float stanceFastJumpForce;

    [Header("Stance 2 Variables")]
    public float stanceStrongMovementSpeed;
    public float stanceStrongJumpForce;

    float movex;

    private void Awake()
    {
        SwitchStance("FAST");
    }

    private void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();

        }

        //All the stance switching code below is pretty straighforward. I just commented out debugs cause they get annoying in console.
        if (Input.GetButtonDown("Stance 1"))
        {
            SwitchStance("FAST");
            //Debug.Log("Switched to " + currentStance + " stance!");
        }
        if (Input.GetButtonDown("Stance 2"))
        {
            SwitchStance("STRONG");
            //Debug.Log("Switched to " + currentStance + " stance!");
        }

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movex * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }


    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;

    }

    public bool IsGrounded()
    {
        //We dont want player clinging to walls in every stance we create, so we are gonna need to find a different way to do this.
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }

    //This function just matches current value of stance and executes blocks of codes based on its value. (Default does nothing ATM)
    public void SwitchStance(string stance)
    {
        if (currentStance == stance)
        {
            Debug.Log("Already in that stance silly goose");
            return;
        }
        else
        {
            switch (stance)
            {
                case "FAST":
                    currentStance = stance;
                    movementSpeed = stanceFastMovementSpeed;
                    jumpForce = stanceFastJumpForce;
                    spriteRender.color = Color.blue;
                    break;
                case "STRONG":
                    currentStance = stance;
                    movementSpeed = stanceStrongMovementSpeed;
                    jumpForce = stanceStrongJumpForce;
                    spriteRender.color = Color.red;
                    break;
                default:
                    break;
            }
        }
    }
}
