using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixieAI : MonoBehaviour
{
    public float speed;
    public float detectionDist;
    public float attackRange;
    public float fireRate = 2f;
    private float nextFireTime;
    private SpriteRenderer sprite;
    public GameObject windGust;
    public GameObject windGustParent;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > player.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distFromPlayer < detectionDist && distFromPlayer > attackRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distFromPlayer <= attackRange && nextFireTime < Time.time)
        {
            Instantiate(windGust, windGustParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionDist);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
