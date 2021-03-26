using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    public Transform feet;
    public LayerMask groundLayers;

    public int jumpMax = 0;
    public int jumpCount = 0;
    public bool canResetJumps;

    [HideInInspector] public bool IsFacingRight = true;

    public string currentEssence;
    public string Projectile;
    public SpriteRenderer spriteRender;

    [Header("Basic Essence Variables")]
    public float BasicEssenceMovementSpeed;
    public float BasicEssenceJumpForce;
    public int BasicEssenceJumpMax;

    [Header("Air Essence Variables")]
    public float airEssenceMovementSpeed;
    public float airEssenceJumpForce;
    public int airEssenceJumpMax;
    

    [Header("Earth Essence Variables")]
    public float earthEssenceMovementSpeed;
    public float earthEssenceJumpForce;
    public int earthEssenceJumpMax;

    float movex;

    private void Awake()
    {
        SwitchEssence("BASIC");
    }

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

        //All the stance switching code below is pretty straighforward. I just commented out debugs cause they get annoying in console.
        if (Input.GetButtonDown("Essence 1"))
        {
            SwitchEssence("AIR");
            //Debug.Log("Switched to " + currentEssence + " stance!");
        }
        if (Input.GetButtonDown("Essence 2"))
        {
            SwitchEssence("EARTH");
            //Debug.Log("Switched to " + currentEssence + " essence!");
        }
        if (Input.GetButtonDown("Essence 0"))
        {
            SwitchEssence("BASIC");
            //Debug.Log("Switched to " + currentEssence + " stance!");
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
        //We dont want player clinging to walls in every stance we create, so we are gonna need to find a different way to do this.
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null && rb.velocity.y == 0)
        {
            jumpCount = 0; 
            //On first player jump jumpCount is incremeneted by 1 but the groundCheck circle is too big so it immediately sets it back to 0.
            return true;
        }
        else
        {
            return false;
        }
    }

    //This function just matches current value of stance and executes blocks of codes based on its value. (Default does nothing ATM)
    public void SwitchEssence(string essence)
    {
        if (currentEssence == essence)
        {
            //Debug.Log("Already imbued with that essence silly goose");
            return;
        }
        else
        {
            switch (essence)
            {
                case "AIR":
                    currentEssence = essence;
                    movementSpeed = airEssenceMovementSpeed;
                    jumpForce = airEssenceJumpForce;
                    jumpMax = airEssenceJumpMax;
                    spriteRender.color = Color.cyan;
                    Projectile = "AirBlast";
                    break;
                case "EARTH":
                    currentEssence = essence;
                    movementSpeed = earthEssenceMovementSpeed;
                    jumpForce = earthEssenceJumpForce;
                    jumpMax = earthEssenceJumpMax;
                    spriteRender.color = Color.green;
                    Projectile = "Rock";
                    break;
                case "BASIC":
                    currentEssence = essence;
                    movementSpeed = BasicEssenceMovementSpeed;
                    jumpForce = BasicEssenceJumpForce;
                    jumpMax = BasicEssenceJumpMax;
                    spriteRender.color = Color.gray;
                    Projectile = "BasicShot";
                    break;
                default:
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//this is the player death
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            //LevelManager.instance.Respawn();
            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(currentScene.name);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            //LevelManager.instance.Respawn();
        }
    }
}
