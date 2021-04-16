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
        if (collision.name.Contains("DeepOne"))
        {
            collision.GetComponent<DeepOneHealthSystem>().TakeDamage(1);
        }
        if (collision.name.Contains("BurningOrb"))
        {
            collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(1);
        }
        if (collision.name.Contains("Ajiva"))
        {
            collision.GetComponent<AjivaHealthSystem>().TakeDamage(1);
        }
    }
}
