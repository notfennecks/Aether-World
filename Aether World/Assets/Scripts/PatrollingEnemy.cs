using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public float health;
    public float CDamage;//stands for contact damage 
    public float speed;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Transform PatrolCheck;

    bool IsFacingRight = true;
    public bool flying;

    RaycastHit2D hit;
    private void Update()
    {
        if (flying == false)
            hit = Physics2D.Raycast(PatrolCheck.position, -transform.up, 1f, groundLayers);//checking when a flying enemy should turn around will be different
        else
            hit = Physics2D.Raycast(PatrolCheck.position, transform.right, 0.25f, groundLayers);//Where the ray is cast is slightly different.
        if (health <= 0)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (flying == false)//if the enemy is on the ground, the collider looks at the gound
        {
            if (hit.collider != false)
            {
                if (IsFacingRight == true)
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                else
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                IsFacingRight = !IsFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            }
        }
        else//if the enemy flies, the collider works the opposite way.
        {
            if (hit.collider == false)
            {
                if (IsFacingRight == true)
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                else
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                IsFacingRight = !IsFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            }
        }
    }
    
}
