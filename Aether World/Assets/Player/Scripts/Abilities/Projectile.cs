using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float ProjectileDamage;

    public float TimeToLive;

    public Rigidbody2D rb;

    public GameObject earthExplosion;
    public bool enemy;

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * ProjectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Pixie"))
        {
            collision.GetComponent<PixieHealthSystem>().TakeDamage(1);
        }
    }
}
