using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDash : MonoBehaviour
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
        if (em.currentEssence == "FIRE" && Input.GetKeyDown(KeyCode.Q))
        {
            if (CanUse == true)
            {
                if (pm.IsFacingRight == true)
                {
                    Vector2 movement = new Vector2(25f, 0f);
                    //movement.x = 20;
                    pm.rb.velocity = movement;
                }
                CoolDownTime = Time.time + CoolDown;
                CanUse = false;
                Debug.Log("Zoom");
            }
        }
        if (CoolDownTime < Time.time)
        {
            CanUse = true;
        }
    }
}
