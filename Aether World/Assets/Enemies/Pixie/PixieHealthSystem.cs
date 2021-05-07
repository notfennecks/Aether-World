using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixieHealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private bool isDying = false;
    private bool isDead = false;
    private float deathAnimTime = 0.7f;
    private Animator anim;

    public GameManager gm;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(isDying)
        {
            deathAnimTime -= Time.deltaTime;
            if(deathAnimTime <= 0.0f)
            {
                isDead = true;
            }
        }
        if(isDead)
        {
            Destroy(this.gameObject);
            gm.pixieKilled += 1;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            isDying = true;
            anim.SetBool("isDying", true);
        }
    }
}
