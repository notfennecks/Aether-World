using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjivaAI : MonoBehaviour
{
    public float speed;
    public float detectDistance;
    public float rockThrowDistance;
    public float fireRate = 2f;
    private float nextFireTime;
    private Transform player;
    private Animator anim;
    public GameObject rock;
    public GameObject rockParent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(player.GetComponent<CapsuleCollider2D>(), GetComponent<BoxCollider2D>());
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.transform.position.x > player.position.x)
        {
            this.transform.localScale = new Vector3(0.6f, 0.6f, 0);
        }
        else
        {
            this.transform.localScale = new Vector3(-0.6f, 0.6f, 0);
        }

        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distFromPlayer < detectDistance && distFromPlayer > rockThrowDistance)
        {
            anim.SetBool("canAttack", false);
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.position.x, this.transform.position.y), speed * Time.deltaTime);
        }

        else if(distFromPlayer <= rockThrowDistance && nextFireTime < Time.time)
        {
            anim.SetBool("canAttack", true);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
        Gizmos.DrawWireSphere(transform.position, rockThrowDistance);
    }

    private void ThrowRock()
    {
        Instantiate(rock, rockParent.transform.position, Quaternion.identity);
    }
}

