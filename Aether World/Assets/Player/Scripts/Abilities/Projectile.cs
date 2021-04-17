using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float ProjectileDamage;
    public GameObject projectile;
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
        if(collision.name.Contains("Base"))
        {
            Destroy(this.gameObject);
            //Debug.Log(projectile.name + " has just hit the ground and was destroyed"); 
        }
        if(projectile.name.Contains("BasicShot"))
        {
            if (collision.name.Contains("Pixie"))
            {
                collision.GetComponent<PixieHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("DeepOne"))
            {
                collision.GetComponent<DeepOneHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("BurningOrb"))
            {
                collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("Ajiva"))
            {
                collision.GetComponent<AjivaHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
        }
        else if (projectile.name.Contains("AirBlast"))
        {
            if (collision.name.Contains("Pixie"))
            {
                collision.GetComponent<PixieHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("DeepOne"))
            {
                collision.GetComponent<DeepOneHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("BurningOrb"))
            {
                collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("Ajiva"))
            {
                collision.GetComponent<AjivaHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
        }
        else if (projectile.name.Contains("FireBurst"))
        {
            if (collision.name.Contains("Pixie"))
            {
                collision.GetComponent<PixieHealthSystem>().TakeDamage(ProjectileDamage + 2);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("DeepOne"))
            {
                collision.GetComponent<DeepOneHealthSystem>().TakeDamage(ProjectileDamage - 1);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("BurningOrb"))
            {
                collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("Ajiva"))
            {
                collision.GetComponent<AjivaHealthSystem>().TakeDamage(ProjectileDamage - 1);
                Destroy(this.gameObject);
            }
        }
        else if (projectile.name.Contains("IceBlast"))
        {
            if (collision.name.Contains("Pixie"))
            {
                collision.GetComponent<PixieHealthSystem>().TakeDamage(ProjectileDamage);
                //Destroy(this.gameObject);
            }
            if (collision.name.Contains("DeepOne"))
            {
                collision.GetComponent<DeepOneHealthSystem>().TakeDamage(ProjectileDamage + 2);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("BurningOrb"))
            {
                collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(ProjectileDamage * 2);
                //Destroy(this.gameObject);
            }
            if (collision.name.Contains("Ajiva"))
            {
                collision.GetComponent<AjivaHealthSystem>().TakeDamage(ProjectileDamage);
                //Destroy(this.gameObject);
            }
        }
        else if (projectile.name.Contains("Rock"))
        {
            if (collision.name.Contains("Pixie"))
            {
                collision.GetComponent<PixieHealthSystem>().TakeDamage(ProjectileDamage + 1);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("DeepOne"))
            {
                collision.GetComponent<DeepOneHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("BurningOrb"))
            {
                collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(ProjectileDamage + 1);
                Destroy(this.gameObject);
            }
            if (collision.name.Contains("Ajiva"))
            {
                collision.GetComponent<AjivaHealthSystem>().TakeDamage(ProjectileDamage);
                Destroy(this.gameObject);
            }
        }
        /*if (collision.name.Contains("Pixie"))
        {
            collision.GetComponent<PixieHealthSystem>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.name.Contains("DeepOne"))
        {
            collision.GetComponent<DeepOneHealthSystem>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.name.Contains("BurningOrb"))
        {
            collision.GetComponent<BurningOrbHealthSystem>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.name.Contains("Ajiva"))
        {
            collision.GetComponent<AjivaHealthSystem>().TakeDamage(1);
            Destroy(this.gameObject);
        }*/
    }
}
