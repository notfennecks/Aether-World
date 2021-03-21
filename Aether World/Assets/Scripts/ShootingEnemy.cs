using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float health;
    public float CDamage;//stands for contact damage 
    public float Range;
    //public float speed; These enemies wont always move. If they do they will have the patrolling enemy script to handle it.
    public Rigidbody2D rb;
    public LayerMask characterLayers;
    public Transform shootRange;
    public Transform FiringPoint;
    public GameObject Projectile;
    public bool IsFacingRight;
    public float FireRate;
    float TimeUntilShoot;
    //public bool flying;
    

    Projectile pro;

    RaycastHit2D hit;

    private void Update()
    {
        if (IsFacingRight == true)
        {
            hit = Physics2D.Raycast(shootRange.position, transform.right, Range, characterLayers);//this will look to see when the player is close

        }
        else if (IsFacingRight == false)
        {
            hit = Physics2D.Raycast(shootRange.position, -transform.right, Range, characterLayers);//this will look to see when the player is close
            
        }
        if (health <= 0)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if (hit.collider == true && TimeUntilShoot < Time.time)
        {
            Debug.Log("A target is in range");
            Projectile = Instantiate(Projectile, FiringPoint.position, FiringPoint.rotation);
            TimeUntilShoot = Time.time + FireRate;
        }
    }
}
