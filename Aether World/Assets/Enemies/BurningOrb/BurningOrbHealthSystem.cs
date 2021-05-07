using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningOrbHealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    public GameManager gm;
    void Start()
    {
        currentHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            gm.burningKilled += 1;
        }
    }
}
