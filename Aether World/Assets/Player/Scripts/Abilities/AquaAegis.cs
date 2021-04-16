using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaAegis : MonoBehaviour
{
    private GameObject player;
    private EssenceManager em;
    private PlayerMovement pm;
    [HideInInspector] public GameObject aquaAegis;
    [HideInInspector] public bool isActive;
    private float baseWaterMoveSpeed;
    [Range(0f, 1.0f)]
    public float aegisMoveMulti;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        em = player.GetComponent<EssenceManager>();
        pm = player.GetComponent<PlayerMovement>();
        aquaAegis = Resources.Load("Prefabs/Player/Abilities/AquaAegis") as GameObject;  //If using Resources.load object must be in "Resources" folder
        aquaAegis = Instantiate(aquaAegis, player.transform.position, Quaternion.identity);
        aquaAegis.transform.parent = player.transform;
        aquaAegis.SetActive(false);
        baseWaterMoveSpeed = em.waterMoveSpeed;
    }

    void Update()
    {
        aquaAegis.transform.position = player.transform.position;
        if (em.currentEssence == "WATER" && Input.GetKeyDown(KeyCode.Q))
        {
            isActive = true;
            aquaAegis.SetActive(true);
            pm.movementSpeed *= aegisMoveMulti;
        }
        else if (em.currentEssence != "WATER")
        {
            isActive = false;
            aquaAegis.SetActive(false);
            pm.movementSpeed = baseWaterMoveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isActive = false;
            aquaAegis.SetActive(false);
            pm.movementSpeed = baseWaterMoveSpeed;
        }
        
    }
}
