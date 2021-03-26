using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PixieAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDist = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    bool canShoot = false;
    private float fireInterval;
    public float startInterval;
    public GameObject projectile;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

        fireInterval = startInterval;
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && transform != null)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if( distance < nextWaypointDist)
        {
            currentWaypoint++;
        }

        if(fireInterval <= 0)
        {
            //Instantiate(projectile, rb.position, Quaternion.identity);
            fireInterval = startInterval;
        }
        else
        {
            fireInterval -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            canShoot = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            canShoot = false;
        }
    }
}
