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

    public new Camera camera;
    Vector2 mousePos;
    public Transform FireRotationPivot;
    private float angle;

    public int airBurstAmount = 3;
    public float airBurstDelay = 0.2f;

    private float chargeStartTime;
    public bool earthChargedState;
    public Vector3 earthPScale;


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




        if (Input.GetMouseButtonDown(1))
        {
            chargeStartTime = Time.time;
        }
        if (Input.GetMouseButton(1))
        {
            earthChargedState = true;
            float chargeTime = Time.time - chargeStartTime;
        }
        if (Input.GetMouseButtonUp(1) && TimeUntilShoot < Time.time && pm.currentEssence == "EARTH")
        {
            float chargeTime = Time.time - chargeStartTime;
            if (chargeTime < 0.5)
                chargeTime = 0.5f;
            earthPScale = new Vector3(chargeTime, chargeTime, 1f);
            Shoot();
            chargeTime = 0.5f;
            TimeUntilShoot = Time.time + FireRate;
            earthChargedState = false;
        }

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - pm.rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        FireRotationPivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        //GameObject airProjectile;

        if (pm.currentEssence == "AIR")
        {
            //airProjectile = Instantiate(AirProjectile, FiringPoint.position, FiringPoint.rotation);
            StartCoroutine("AirBurst");
        }

        else if (pm.currentEssence == "EARTH")
        {
            GameObject earthProjectile = Instantiate(EarthProjectile, FiringPoint.position, FiringPoint.rotation);
            earthProjectile.transform.localScale = earthPScale;
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

    private float CalculateChargeForce(float chargeTime)
    {
        float maxChargeTime = 2f;
        float chargeTimeNormalized = Mathf.Clamp01(chargeTime / maxChargeTime);
        return chargeTimeNormalized;
    }

}