using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepOneAI : MonoBehaviour
{
    public float speed;
    public float detectDistance;
    public float spitDistance;
    private Transform player;
    private Animator anim;
    public GameObject spit;
    public GameObject spitParent;
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
            this.transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 0);
        }

        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distFromPlayer < detectDistance && distFromPlayer > spitDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.position.x, this.transform.position.y), speed * Time.deltaTime);
        }
        if(distFromPlayer < spitDistance)
        {
            anim.SetBool("canAttack", true);
        }
        else
        {
            anim.SetBool("canAttack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
        Gizmos.DrawWireSphere(transform.position, spitDistance);
    }

    private void Spit()
    {
        Instantiate(spit, spitParent.transform.position, Quaternion.identity);
    }
}
