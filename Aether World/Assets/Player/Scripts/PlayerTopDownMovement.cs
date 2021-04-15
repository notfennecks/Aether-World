using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  //Player speed

    public Rigidbody2D rb;  //Stores player rigidbody2d component

    Vector2 movement;  //Used to store player move direction

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");  //If moving right = 1 | if moving left = -1
        movement.y = Input.GetAxisRaw("Vertical"); //If moving up = 1 | if moving down = -1
        movement.Normalize();  //So you dont move faster when moving diagonally
        if (movement.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        if (movement.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);  //Sets new position every frame based on movement vector
    }
}
