using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceIconManager : MonoBehaviour
{
    [SerializeField] private GameObject basicIcon;
    [SerializeField] private GameObject airIcon;
    [SerializeField] private GameObject earthIcon;
    [SerializeField] private GameObject fireIcon;
    [SerializeField] private GameObject waterIcon;

    public void switchEssenceIcon(string essence)
    {
        switch (essence)
        {
            case "AIR":
                airIcon.SetActive(true);
                basicIcon.SetActive(false);
                earthIcon.SetActive(false);
                waterIcon.SetActive(false);
                fireIcon.SetActive(false);
                break;
            case "EARTH":
                earthIcon.SetActive(true);
                basicIcon.SetActive(false);
                airIcon.SetActive(false);
                waterIcon.SetActive(false);
                fireIcon.SetActive(false);
                break;
            case "WATER":
                waterIcon.SetActive(true);
                basicIcon.SetActive(false);
                airIcon.SetActive(false);
                earthIcon.SetActive(false);
                fireIcon.SetActive(false);
                break;
            case "FIRE":
                fireIcon.SetActive(true);
                basicIcon.SetActive(false);
                airIcon.SetActive(false);
                earthIcon.SetActive(false);
                waterIcon.SetActive(false);
                break;
            case "BASIC":
                basicIcon.SetActive(true);
                airIcon.SetActive(false);
                earthIcon.SetActive(false);
                waterIcon.SetActive(false);
                fireIcon.SetActive(false);
                break;
            default:
                break;
        }
    }
}
