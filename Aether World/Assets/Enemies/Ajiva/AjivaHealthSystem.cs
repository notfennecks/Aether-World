using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjivaHealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private bool isdying = false;
    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }
}
