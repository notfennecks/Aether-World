using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningOrbAI : MonoBehaviour
{
    public float speed;
    public float detectRadius;
    public float fireAOERadius;
    private float stopRadius = 2f;
    public float tickRate;
    private float nextTickTime;
    private Transform player;
    private SpriteRenderer sprite;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.transform.position.x > player.position.x)
        {
            sprite.flipX = false;
        }
        else if (this.transform.position.x < player.position.x)
        {
            sprite.flipX = true;
        }
        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distFromPlayer < detectRadius && distFromPlayer > stopRadius)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        if (distFromPlayer <= fireAOERadius )
        {
            if (nextTickTime < Time.time)
            {
                nextTickTime = Time.time + tickRate;
                player.GetComponent<PlayerHealthSystem>().takeDamage(2);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireAOERadius);
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
