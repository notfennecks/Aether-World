using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepOneHealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
