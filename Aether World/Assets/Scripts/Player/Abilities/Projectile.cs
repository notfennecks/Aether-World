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
        rb.velocity = -transform.right * ProjectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Player" && enemy == false)
        {
            /*if (name == "Rock(Clone)")
            {
                GameObject effect = Instantiate(earthExplosion, transform.position, Quaternion.identity);
                Destroy(effect, 1.2f);
            }*/
            //Destroy(gameObject);
        }
    }
}
