using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [Header("Animation Variables")]
    public Animator overworldAnimator;
    public Animator terraAnimator;
    public Animator scoriaAnimator;
    public Animator eldorisAnimator;
    public Animator zephyrAnimator;

    [Header("Audio Source Variables")]
    public AudioSource overworldSelect;
    public AudioSource overworldHover;
    public AudioSource terraSelect;
    public AudioSource terraHover;
    public AudioSource scoriaSelect;
    public AudioSource scoriaHover;
    public AudioSource eldorisSelect;
    public AudioSource eldorisHover;
    public AudioSource zephyrSelect;
    public AudioSource zephyrHover;

    public void SelectOverworld()
    {
        //Debug.Log("Selected Overworld!");
        if (overworldSelect.isPlaying != true)
            overworldSelect.Play();
    }

    public void HoverOverworld()
    {
        overworldAnimator.Play("OverworldGrow");
        overworldHover.Play();
    }

    public void ExitHoverOverworld()
    {
        overworldAnimator.Play("OverworldShrink");
    }

    public void SelectTerra()
    {
        //Debug.Log("Selected Terra!");
        terraSelect.Play();
    }

    public void HoverTerra()
    {
        terraAnimator.Play("TerraGrow");
        terraHover.Play();
    }

    public void ExitHoverTerra()
    {
        terraAnimator.Play("TerraShrink");
    }

    public void SelectScoria()
    {
        //Debug.Log("Selected Scoria!");
        scoriaSelect.Play();
    }

    public void HoverScoria()
    {
        scoriaAnimator.Play("ScoriaGrow");
        scoriaHover.Play();
    }

    public void ExitHoverScoria()
    {
        scoriaAnimator.Play("ScoriaShrink");
    }

    public void SelectEldoris()
    {
        //Debug.Log("Selected Eldoris!");
        eldorisSelect.Play();
    }

    public void HoverEldoris()
    {
        eldorisAnimator.Play("EldorisGrow");
        eldorisHover.Play();
    }

    public void ExitHoverEldoris()
    {
        eldorisAnimator.Play("EldorisShrink");
    }

    public void SelectZephyr()
    {
        //Debug.Log("Selected Zephyr!");
        zephyrSelect.Play();
    }

    public void HoverZephyr()
    {
        zephyrAnimator.Play("ZephyrGrow");
        zephyrHover.Play();
    }

    public void ExitHoverZephyr()
    {
        zephyrAnimator.Play("ZephyrShrink");
    }

}
