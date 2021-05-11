using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirJump : MonoBehaviour
{
    private GameObject player;
    private EssenceManager em;
    private PlayerMovement pm;
    private bool CanUse;
    public float CoolDown;
    float CoolDownTime;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        em = player.GetComponent<EssenceManager>();
        pm = player.GetComponent<PlayerMovement>();
        CanUse = true;
    }

    void Update()
    {
        if (em.currentEssence == "AIR" && Input.GetKeyDown(KeyCode.Q))
        {
            if (CanUse == true)
            {
                Vector2 movement = new Vector2(pm.rb.velocity.x, 25f);
                pm.rb.velocity = movement;
                CoolDownTime = Time.time + CoolDown;
                CanUse = false;
                //Debug.Log("Boing");
            }
        }
        if (CoolDownTime < Time.time)
        {
            CanUse = true;
        }
    }
    
}
