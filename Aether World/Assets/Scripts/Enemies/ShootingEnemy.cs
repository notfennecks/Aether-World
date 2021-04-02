using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float health;
    public float CDamage;//stands for contact damage 
    //public float speed;
    public Rigidbody2D rb;
    public LayerMask TargetLayers;
    public Transform ShootRange;
    public Transform FiringPoint;
    public bool IsFacingRight;
    public GameObject Projectile;
    float TimeUntilShoot;
    public float FireRate;
    Projectile pro;

    RaycastHit2D hit;
    private void Update()
    {
        if (IsFacingRight == true)
            hit = Physics2D.Raycast(ShootRange.position, transform.right, 5f, TargetLayers);//checking when a flying enemy should turn around will be different
        else if (IsFacingRight == false)
            hit = Physics2D.Raycast(ShootRange.position, -transform.right, 5f, TargetLayers);//Where the ray is cast is slightly different.
        if (health <= 0)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if (hit.collider == true)
        {
            //Debug.Log("A target is in range");
            if(TimeUntilShoot < Time.time)
            {
                TimeUntilShoot = Time.time + FireRate;
                GameObject projectile = Instantiate(Projectile, FiringPoint.position, FiringPoint.rotation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Debug.Log("I was shot by " + collision.collider.name);
            if (collision.collider.name == "BasicShot(Clone)")
                health = health - 2;
            if (collision.collider.name == "AirBlast(Clone)")
                health = health - 1;

        }
    }
}
