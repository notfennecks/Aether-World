using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShield : MonoBehaviour
{
    public float FireRate;
    public Transform FiringPoint;
    float TimeUntilShoot;
    public GameObject watershield;
    EssenceManager em;
    PlayerShoot ps;
    private Rigidbody2D player_rb;
    public new Camera camera;
    Vector2 mousePos;
    public Transform FireRotationPivot;
    private float angle;

    private void Start()//this code will be similar to the player shoot, at least for now.
    {
        em = gameObject.GetComponent<EssenceManager>();
        player_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(em.currentEssence == "WATER")
        {
            if (Input.GetMouseButtonDown(0) && TimeUntilShoot < Time.time)//Makes sure the player is in the water essence and they can "shoot"
            {
                Shield();
                TimeUntilShoot = Time.time + FireRate;
            }
        }
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Shield()
    {
        GameObject Watershield = Instantiate(watershield, FiringPoint.position, FiringPoint.rotation);
    }
}
