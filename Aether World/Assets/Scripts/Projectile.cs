using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float ProjectileDamage;

    public Rigidbody2D rb;


    private void FixedUpdate()
    {
        rb.velocity = transform.right * ProjectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
