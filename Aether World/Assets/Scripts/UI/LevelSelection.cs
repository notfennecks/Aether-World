using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static LevelSelection instance;

    [Header("Animation Variables")]
    public Animator overworldAnimator;
    public Animator terraAnimator;
    public Animator scoriaAnimator;
    public Animator eldorisAnimator;
    public Animator zephyrAnimator;
    public Animator cameraAnimator;

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

    [HideInInspector]
    public bool canHover = true;

    public bool unlocked;


    public Image unlockImage;

    //public GoalPoint gp;
    public GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //UpdateLevelImage();
        //gp = gameObject.GetComponent<GoalPoint>();
        //UpdateLevelStatus();
    }


    public void SelectSocialSpace()
    {
        SceneManager.LoadScene("SocialSpace");
    }

    public void SelectOverworld()
    {
        //Debug.Log("Selected Overworld!");
        canHover = false;
        if (overworldSelect.isPlaying != true)
            overworldSelect.Play();
        cameraAnimator.SetBool("OverworldSelected", true);
    }

    public void HoverOverworld()
    {
        if (canHover)
        {
            overworldAnimator.Play("OverworldGrow");
            overworldHover.Play();
        }
    }

    public void ExitHoverOverworld()
    {
        if (canHover)
        {
            overworldAnimator.Play("OverworldShrink");
        }
    }

    public void SelectTerra()
    {
        //Debug.Log("Selected Terra!");
        canHover = false;
        if (terraSelect.isPlaying != true)
            terraSelect.Play();
        cameraAnimator.SetBool("TerraSelected", true);
    }

    public void HoverTerra()
    {
        if (canHover)
        {
            terraAnimator.Play("TerraGrow");
            terraHover.Play();
        }
    }

    public void ExitHoverTerra()
    {
        if (canHover)
        {
            terraAnimator.Play("TerraShrink");
        }
    }

    public void SelectScoria()
    {
        //Debug.Log("Selected Scoria!");
        canHover = false;
        if (scoriaSelect.isPlaying != true)
            scoriaSelect.Play();
        cameraAnimator.SetBool("ScoriaSelected", true);
    }

    public void HoverScoria()
    {
        if (canHover)
        {
            scoriaAnimator.Play("ScoriaGrow");
            scoriaHover.Play();
        }
    }

    public void ExitHoverScoria()
    {
        if (canHover)
        {
            scoriaAnimator.Play("ScoriaShrink");
        }
    }

    public void SelectEldoris()
    {
        //Debug.Log("Selected Eldoris!");
        canHover = false;
        if (eldorisSelect.isPlaying != true)
            eldorisSelect.Play();
        cameraAnimator.SetBool("EldorisSelected", true);
    }

    public void HoverEldoris()
    {
        if (canHover)
        {
            eldorisAnimator.Play("EldorisGrow");
            eldorisHover.Play();
        }
    }

    public void ExitHoverEldoris()
    {
        if (canHover)
        {
            eldorisAnimator.Play("EldorisShrink");
        }
    }

    public void SelectZephyr()
    {
        //Debug.Log("Selected Zephyr!");
        canHover = false;
        if (zephyrSelect.isPlaying != true)
            zephyrSelect.Play();
        cameraAnimator.SetBool("ZephyrSelected", true);
    }

    public void HoverZephyr()
    {
        if (canHover)
        {
            zephyrAnimator.Play("ZephyrGrow");
            zephyrHover.Play();
        }
    }

    public void ExitHoverZephyr()
    {
        if (canHover)
        {
            zephyrAnimator.Play("ZephyrShrink");
        }
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
        }
    }

    public void UpdateLevelStatus()
    {
        
        
        
        
    }

    public void overworld01()
    {
        SceneManager.LoadScene("Overworld01");
    }

    public void overworld02()
    {
        SceneManager.LoadScene("Overworld02");
    }

    public void overworld03()
    {
        SceneManager.LoadScene("Overworld03");
    }

    public void terra01()
    {
        SceneManager.LoadScene("Terra01");
    }

    public void terra02()
    {
        SceneManager.LoadScene(GameManager.Terra2.SceneName);
    }

    public void terra03()
    {
        SceneManager.LoadScene("Terra03");
    }

    public void eldoris01()
    {
        SceneManager.LoadScene("Eldoris01");
    }

    public void eldoris02()
    {
        SceneManager.LoadScene("Eldoris02");
    }

    public void eldoris03()
    {
        SceneManager.LoadScene("Eldoris03");
    }

    public void scoria01()
    {
        SceneManager.LoadScene("Scoria01");
    }

    public void scoria02()
    {
        SceneManager.LoadScene("Scoria02");
    }

    public void scoria03()
    {
        SceneManager.LoadScene("Scoria03");
    }

    public void zephyr01()
    {
        SceneManager.LoadScene("Zephyr01");
    }

    public void zephyr02()
    {
        SceneManager.LoadScene("Zephyr02");
    }

    public void zephyr03()
    {
        SceneManager.LoadScene("Zephyr03");
    }
}
