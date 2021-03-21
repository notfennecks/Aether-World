using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public Animator overworldAnimator;
    public Animator terraAnimator;
    public Animator scoriaAnimator;
    public Animator eldorisAnimator;
    public Animator zephyrAnimator;

    public void SelectOverworld()
    {
        Debug.Log("Selected Overworld!");
    }

    public void HoverOverworld()
    {
        overworldAnimator.Play("OverworldGrow");
    }

    public void ExitHoverOverworld()
    {
        overworldAnimator.Play("OverworldShrink");
    }

    public void SelectTerra()
    {
        Debug.Log("Selected Terra!");
    }

    public void HoverTerra()
    {
        terraAnimator.Play("TerraGrow");
    }

    public void ExitHoverTerra()
    {
        terraAnimator.Play("TerraShrink");
    }

    public void SelectScoria()
    {
        Debug.Log("Selected Scoria!");
    }

    public void HoverScoria()
    {
        scoriaAnimator.Play("ScoriaGrow");
    }

    public void ExitHoverScoria()
    {
        scoriaAnimator.Play("ScoriaShrink");
    }

    public void SelectEldoris()
    {
        Debug.Log("Selected Eldoris!");
    }

    public void HoverEldoris()
    {
        eldorisAnimator.Play("EldorisGrow");
    }

    public void ExitHoverEldoris()
    {
        eldorisAnimator.Play("EldorisShrink");
    }

    public void SelectZephyr()
    {
        Debug.Log("Selected Zephyr!");
    }

    public void HoverZephyr()
    {
        zephyrAnimator.Play("ZephyrGrow");
    }

    public void ExitHoverZephyr()
    {
        zephyrAnimator.Play("ZephyrShrink");
    }
}
