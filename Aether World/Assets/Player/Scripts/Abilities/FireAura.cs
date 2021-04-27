using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAura : MonoBehaviour
{
    private GameObject player;
    private EssenceManager em;
    private PlayerMovement pm;
    private PlayerHealthSystem ph;
    public float fireAOERadius;
    //public float tickRate;
    //private float nextTickTime;
    private Transform enemy;
    //private bool CanUse;
    public float CoolDown;
    float CoolDownTime;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
        em = player.GetComponent<EssenceManager>();
        pm = player.GetComponent<PlayerMovement>();
        ph = player.GetComponent<PlayerHealthSystem>();
        //CanUse = true;
    }

    void Update()
    {
        if (em.currentEssence == "FIRE" && Input.GetKeyDown(KeyCode.E))
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            float distFromEnemy = Vector2.Distance(enemy.position, transform.position);
            if (ph.currentAether >= 10)
            {
                if (distFromEnemy <= fireAOERadius)
                {
                    if (CoolDownTime < Time.time)
                    {
                        if(enemy.name.Contains("DeepOne"))
                        {
                            enemy.GetComponent<DeepOneHealthSystem>().TakeDamage(1);
                        }
                        CoolDownTime = Time.time + CoolDown;
                        ph.currentAether -= 10;
                        Debug.Log("fwoosh");
                    }
                }
                
            }
        }
    }
}
