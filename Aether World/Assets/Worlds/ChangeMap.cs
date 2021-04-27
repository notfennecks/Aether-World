using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMap : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject worlds;
    public GameObject overworldMap;
    public GameObject terraMap;
    public GameObject scoriaMap;
    public GameObject eldorisMap;
    public GameObject zephyrMap;

    public Animator cameraAnim;

    public Button overworld;
    public Button terra;
    public Button scoria;
    public Button eldoris;
    public Button zephyr;

    public LevelSelection level;

    public void ButtonToggle()
    {
        if (overworld.interactable == true)
            overworld.interactable = false;
        else
            overworld.interactable = true;
        //-------------------------------------------------
        if (terra.interactable == true)
            terra.interactable = false;
        else
            terra.interactable = true;
        //-------------------------------------------------
        if (scoria.interactable == true)
            scoria.interactable = false;
        else
            scoria.interactable = true;
        //-------------------------------------------------
        if (eldoris.interactable == true)
            eldoris.interactable = false;
        else
            eldoris.interactable = true;
        //-------------------------------------------------
        if (zephyr.interactable == true)
            zephyr.interactable = false;
        else
            zephyr.interactable = true;
    }

    void Start()
    {
        worlds.SetActive(true);
        overworldMap.SetActive(false);
        terraMap.SetActive(false);
        scoriaMap.SetActive(false);
        eldorisMap.SetActive(false);
        zephyrMap.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true && worlds.activeSelf == false)
        {
            ButtonToggle();
            worlds.SetActive(true);
            if (overworldMap.activeSelf == true)
            {
                overworldMap.SetActive(false);
            }
            else if (terraMap.activeSelf == true)
            {
                terraMap.SetActive(false);
            }
            else if (scoriaMap.activeSelf == true)
            {
                scoriaMap.SetActive(false);
            }
            else if (eldorisMap.activeSelf == true)
            {
                eldorisMap.SetActive(false);
            }
            else if (zephyrMap.activeSelf == true)
            {
                zephyrMap.SetActive(false);
            }
        }
    }

    public void OverworldChange()
    {
        level.canHover = true;
        overworldMap.SetActive(true);
        worlds.SetActive(false);
        cameraAnim.SetBool("OverworldSelected", false);
    }
    public void TerraChange()
    {
        level.canHover = true;
        terraMap.SetActive(true);
        worlds.SetActive(false);
        cameraAnim.SetBool("TerraSelected", false);
    }

    public void ScoriaChange()
    {
        level.canHover = true;
        scoriaMap.SetActive(true);
        worlds.SetActive(false);
        cameraAnim.SetBool("ScoriaSelected", false);
    }
    public void EldorisChange()
    {
        level.canHover = true;
        eldorisMap.SetActive(true);
        worlds.SetActive(false);
        cameraAnim.SetBool("EldorisSelected", false);
    }
    public void ZephyrChange()
    {
        level.canHover = true;
        zephyrMap.SetActive(true);
        worlds.SetActive(false);
        cameraAnim.SetBool("ZephyrSelected", false);
    }
}
