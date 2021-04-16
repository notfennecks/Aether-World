using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    private float speed;
    Rigidbody2D rockRB;
    GameObject target;
    void Start()
    {
        speed = 3f;
        rockRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        moveDir.y += 5;
        rockRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Base")
        {
            Destroy(this.gameObject);
        }
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerHealthSystem>().takeDamage(10);
        }
    }
}
