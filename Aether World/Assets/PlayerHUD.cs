using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Image basicAtkIcon;
    public Image abi1Icon;
    public Image abil2Icon;

    public Sprite basic0;
    public Sprite air0;
    public Sprite earth0;
    public Sprite water0;
    public Sprite fire0;

    private EssenceManager em;

    void Start()
    {
        em = GetComponentInParent<EssenceManager>();
    }
    void Update()
    {
        if (em.currentEssence == "BASIC")
        {
            basicAtkIcon.sprite = basic0;
        }
        else if (em.currentEssence == "AIR")
        {
            basicAtkIcon.sprite = air0;
        }
        else if (em.currentEssence == "EARTH")
        {
            basicAtkIcon.sprite = earth0;
        }
        else if (em.currentEssence == "WATER")
        {
            basicAtkIcon.sprite = water0;
        }
        else if (em.currentEssence == "FIRE")
        {
            basicAtkIcon.sprite = fire0;
        }
    }
}
