using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int HealthAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
        {
            collision.GetComponent<PlayerHealthSystem>().gainHealth(HealthAmount);
            Destroy(this.gameObject);
        }

    }

}
