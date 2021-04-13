using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D spitRB;

    void Start()
    {
        spitRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        spitRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerHealthSystem>().takeDamage(20);
        }
    }
}
