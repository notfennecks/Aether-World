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

    [Header("UI Panels")]
    public GameObject worlds;
    public GameObject overworldMap;
    public GameObject terraMap;
    public GameObject scoriaMap;
    public GameObject eldorisMap;
    public GameObject zephyrMap;

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
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
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

    public void SelectSocialSpace()
    {
        SceneManager.LoadScene("SocialSpace");
    }

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
        SceneManager.LoadScene("Terra02");
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
