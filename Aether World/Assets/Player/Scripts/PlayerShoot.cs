using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float FireRate;
    public Transform FiringPoint;
    public GameObject AirProjectile;
    public GameObject EarthProjectile;
    public GameObject BasicProjectile;
    public GameObject WaterProjectile;
    public GameObject FireProjectile;
    float TimeUntilShoot;
    EssenceManager em;
    private Rigidbody2D player_rb;

    public new Camera camera;
    Vector2 mousePos;
    public Transform FireRotationPivot;
    private float angle;

    public int airBurstAmount = 3;
    public float airBurstDelay = 0.2f;


    private void Start()//this figures out which way the player is facing, see player movement to see how it works
    {
        em = gameObject.GetComponent<EssenceManager>();
        player_rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        if (em.currentEssence == "AIR")
            FireRate = 1;
        else if (em.currentEssence == "EARTH")
            FireRate = 1.5f;
        else if (em.currentEssence == "WATER")
            FireRate = 1.25f;
        else if (em.currentEssence == "FIRE")
            FireRate = 0.5f;
        else if (em.currentEssence == "BASIC")
            FireRate = 0.5f;
        if (Input.GetMouseButtonDown(0) && TimeUntilShoot < Time.time)//checks to see if the player can shoot yet
        {
            Shoot();
            TimeUntilShoot = Time.time + FireRate;
        }

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - player_rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        FireRotationPivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {

        if (em.currentEssence == "AIR")
        {
            StartCoroutine("AirBurst");
        }

        else if (em.currentEssence == "EARTH")
        {
            GameObject earthProjectile = Instantiate(EarthProjectile, FiringPoint.position, FiringPoint.rotation);
        }
        else if (em.currentEssence == "BASIC")
        {
            GameObject basicProjectile = Instantiate(BasicProjectile, FiringPoint.position, FiringPoint.rotation);


        }
        else if (em.currentEssence == "FIRE")
        {
            GameObject fireProjectile = Instantiate(FireProjectile, FiringPoint.position, FiringPoint.rotation);


        }
        else if (em.currentEssence == "WATER")
        {
            GameObject waterProjectile = Instantiate(WaterProjectile, FiringPoint.position, FiringPoint.rotation);


        }
    }

    public IEnumerator AirBurst()
    {

        for (int i = 0; i < 3; i++)
        {
            Instantiate(AirProjectile, FiringPoint.position, FiringPoint.rotation);

            yield return new WaitForSeconds(airBurstDelay);
        }
    }
}