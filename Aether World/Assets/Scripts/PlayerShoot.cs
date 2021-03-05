using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float FireRate;
    public Transform FiringPoint;
    public GameObject AirProjectile;
    public GameObject EarthProjectile;
    float TimeUntilShoot;
    PlayerMovement pm;
   

    private void Start()//this figures out which way the player is facing, see player movement to see how it works
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }


    private void Update()
    {

        if (pm.currentEssence == "AIR")
            FireRate = 0.25f;
        else if (pm.currentEssence == "EARTH")
            FireRate = 0.5f;
        if (Input.GetMouseButtonDown(0) && TimeUntilShoot < Time.time)//checks to see if the player can shoot yet
        {
            Shoot();
            TimeUntilShoot = Time.time + FireRate;
        }

    }

    void Shoot()
    {
        float angle = pm.IsFacingRight ? 0 : 180;//is the player facing right? Yes means it goes normal, no means it shoots backwards.
        if (pm.currentEssence == "AIR")
            Instantiate(AirProjectile, FiringPoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        else if (pm.currentEssence == "EARTH")
            Instantiate(EarthProjectile, FiringPoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
    }

}
