using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public bool canAccelDeccel;
    [Range(0.1f, 100.0f)]
    public float acceleration;
    [Range(0.1f, 100.0f)]
    public float decceleration;
    public float jumpForce;
    private float cutJumpForce = 0.5f;  //Variable for if you hold jump the higher you jump
    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private float SlopeCheckDistance;

    [SerializeField] private LayerMask groundLayerMask;
    private BoxCollider2D playerHitbox;

    public int jumpMax = 0;
    public int jumpCount = 0;

    private bool IsFacingRight = true;

    float movex;


    private void Start()
    {
        playerHitbox = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed.x", Mathf.Abs(movex));

        if(movex > 0)
        {
            IsFacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movex < 0)
        {
            IsFacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && ((jumpCount < jumpMax) || IsGrounded()))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpForce);
            }
        }

        if (rb.velocity.y > 0)
        {
            animator.SetBool("IsJumpingUp", true);
            animator.SetBool("IsJumpingDown", false);
        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool("IsJumpingUp", false);
            animator.SetBool("IsJumpingDown", true);
        }
        else
        {
            animator.SetBool("IsJumpingUp", false);
            animator.SetBool("IsJumpingDown", false);
        }

        IsGrounded();
        SlopeCheck();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(rb.velocity.x, rb.velocity.y);   
        if (canAccelDeccel == false)
        {
            movement.x = movementSpeed * movex;
        }
        else
        {
            movement.x += movementSpeed * movex * acceleration * Time.deltaTime;
            if (movement.x > 0 && movex == 0)
            {
                movement.x -= movementSpeed * decceleration * Time.deltaTime;
                if (rb.velocity.x < 0)
                {
                    movement.x = 0;
                }
            }
            if (movement.x < 0 && movex == 0)
            {
                movement.x += movementSpeed * decceleration * Time.deltaTime;
                if (rb.velocity.x > 0)
                {
                    movement.x = 0;
                }
            }
        }
        movement.x = Mathf.Clamp(movement.x, -movementSpeed, movementSpeed);
        rb.velocity = movement;
    }

    private void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        if (jumpCount < jumpMax)
        {
            rb.velocity = movement;
            jumpCount++;
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerHitbox.bounds.center, playerHitbox.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        Color rayColor;

        if ( raycastHit.collider != null && rb.velocity.y == 0)
        {
            rayColor = Color.green;
            jumpCount = 0;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerHitbox.bounds.center + new Vector3(playerHitbox.bounds.extents.x, -playerHitbox.bounds.extents.y), Vector2.down * extraHeight, rayColor);
        Debug.DrawRay(playerHitbox.bounds.center + new Vector3(-playerHitbox.bounds.extents.x, -playerHitbox.bounds.extents.y), Vector2.down * extraHeight, rayColor);
        Debug.DrawRay(playerHitbox.bounds.center + new Vector3(playerHitbox.bounds.extents.x, -playerHitbox.bounds.extents.y - extraHeight), Vector2.left * playerHitbox.bounds.extents.x * 2, rayColor);
        return raycastHit.collider != null;
    }
    public void SlopeCheck()
    {
        float extraHeight = 0.2f;
        //Vector2 checkPosition = transform.position - new Vector3(0.0f, playerHitbox.bounds.size.y / 2);
        RaycastHit2D Hit = Physics2D.BoxCast(playerHitbox.bounds.center, playerHitbox.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        if (Hit)
        {
            Debug.DrawRay(Hit.point, Hit.normal);
        }
    }
}
