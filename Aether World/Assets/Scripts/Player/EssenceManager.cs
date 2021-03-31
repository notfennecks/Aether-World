using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceManager : MonoBehaviour
{
    PlayerMovement pm;
    public string currentEssence;
    private SpriteRenderer playerSprite;
    private EssenceIconManager eiconmanage;

    [Header("Basic Essence Variables")]
    public float basicMoveSpeed;
    public float basicJumpForce;
    public int basicMaxJumps;

    [Header("Air Essence Variables")]
    public float airMoveSpeed;
    public float airJumpForce;
    public int airMaxJumps;

    [Header("Earth Essence Variables")]
    public float earthMoveSpeed;
    public float earthJumpForce;
    public int earthMaxJumps;

    [Header("Water Essence Variables")]
    public float waterMoveSpeed;
    public float waterJumpForce;
    public int waterMaxJumps;

    [Header("Fire Essence Variables")]
    public float fireMoveSpeed;
    public float fireJumpForce;
    public int fireMaxJumps;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        eiconmanage = GetComponentInChildren<EssenceIconManager>();
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
        if (Input.GetButtonDown("Essence 3"))
        {
            SwitchEssence("WATER");
            //Debug.Log("Switched to " + currentEssence + " essence!");
        }
        if (Input.GetButtonDown("Essence 4"))
        {
            SwitchEssence("FIRE");
            //Debug.Log("Switched to " + currentEssence + " stance!");
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
                    pm.movementSpeed = airMoveSpeed;
                    pm.jumpForce = airJumpForce;
                    pm.jumpMax = airMaxJumps;
                    playerSprite.color = Color.cyan;
                    eiconmanage.switchEssenceIcon("AIR");
                    break;
                case "EARTH":
                    currentEssence = essence;
                    pm.movementSpeed = earthMoveSpeed;
                    pm.jumpForce = earthJumpForce;
                    pm.jumpMax = earthMaxJumps;
                    playerSprite.color = Color.green;
                    eiconmanage.switchEssenceIcon("EARTH");
                    break;
                case "WATER":
                    currentEssence = essence;
                    pm.movementSpeed = waterMoveSpeed;
                    pm.jumpForce = waterJumpForce;
                    pm.jumpMax = waterMaxJumps;
                    playerSprite.color = Color.blue;
                    eiconmanage.switchEssenceIcon("WATER");
                    break;
                case "FIRE":
                    currentEssence = essence;
                    pm.movementSpeed = fireMoveSpeed;
                    pm.jumpForce = fireJumpForce;
                    pm.jumpMax = fireMaxJumps;
                    playerSprite.color = Color.red;
                    eiconmanage.switchEssenceIcon("FIRE");
                    break;
                case "BASIC":
                    currentEssence = essence;
                    pm.movementSpeed = basicMoveSpeed;
                    pm.jumpForce = basicJumpForce;
                    pm.jumpMax = basicMaxJumps;
                    playerSprite.color = Color.gray;
                    eiconmanage.switchEssenceIcon("BASIC");
                    break;
                default:
                    break;
            }
        }
    }
}
