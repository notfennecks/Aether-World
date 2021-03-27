using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceManager : MonoBehaviour
{
    PlayerMovement pm;
    public string currentEssence;
    private SpriteRenderer playerSprite;

    [Header("Basic Essence Variables")]
    public float BasicEssenceMovementSpeed;
    public float BasicEssenceJumpForce;
    public int BasicEssenceJumpMax;

    [Header("Air Essence Variables")]
    public float airEssenceMovementSpeed;
    public float airEssenceJumpForce;
    public int airEssenceJumpMax;

    [Header("Earth Essence Variables")]
    public float earthEssenceMovementSpeed;
    public float earthEssenceJumpForce;
    public int earthEssenceJumpMax;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        SwitchEssence("BASIC");
    }

    
    void Update()
    {
        //All the stance switching code below is pretty straighforward. I just commented out debugs cause they get annoying in console.
        if (Input.GetButtonDown("Essence 1"))
        {
            SwitchEssence("AIR");
            //Debug.Log("Switched to " + currentEssence + " stance!");
        }
        if (Input.GetButtonDown("Essence 2"))
        {
            SwitchEssence("EARTH");
            //Debug.Log("Switched to " + currentEssence + " essence!");
        }
        if (Input.GetButtonDown("Essence 0"))
        {
            SwitchEssence("BASIC");
            //Debug.Log("Switched to " + currentEssence + " stance!");
        }
    }


    private void SwitchEssence(string essence)
    {
        if (currentEssence == essence)
        {
            //Debug.Log("Already imbued with that essence silly goose");
            return;
        }
        else
        {
            switch (essence)
            {
                case "AIR":
                    currentEssence = essence;
                    pm.movementSpeed = airEssenceMovementSpeed;
                    pm.jumpForce = airEssenceJumpForce;
                    pm.jumpMax = airEssenceJumpMax;
                    playerSprite.color = Color.cyan;
                    //Projectile = "AirBlast";
                    break;
                case "EARTH":
                    currentEssence = essence;
                    pm.movementSpeed = earthEssenceMovementSpeed;
                    pm.jumpForce = earthEssenceJumpForce;
                    pm.jumpMax = earthEssenceJumpMax;
                    playerSprite.color = Color.green;
                    //Porjectile = "Rock";
                    break;
                case "BASIC":
                    currentEssence = essence;
                    pm.movementSpeed = BasicEssenceMovementSpeed;
                    pm.jumpForce = BasicEssenceJumpForce;
                    pm.jumpMax = BasicEssenceJumpMax;
                    playerSprite.color = Color.gray;
                    //Projectile = "BasicShot";
                    break;
                default:
                    break;
            }
        }
    }
}
