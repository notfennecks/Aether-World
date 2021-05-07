using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject progressMenu;

    public GameObject airProgress;
    public GameObject earthProgress;
    public GameObject waterProgress;
    public GameObject fireProgress;

    GameManager gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !controlsMenu.activeSelf && !progressMenu.activeSelf)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        airProgress.GetComponent<TextMeshProUGUI>().text = gm.AirE.currentAmount.ToString() + " / " + gm.AirE.amountToUnlock.ToString();
        earthProgress.GetComponent<TextMeshProUGUI>().text = gm.EarthE.currentAmount.ToString() + " / " + gm.EarthE.amountToUnlock.ToString();
        waterProgress.GetComponent<TextMeshProUGUI>().text = gm.WaterE.currentAmount.ToString() + " / " + gm.WaterE.amountToUnlock.ToString();
        fireProgress.GetComponent<TextMeshProUGUI>().text = gm.FireE.currentAmount.ToString() + " / " + gm.FireE.amountToUnlock.ToString();

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Controls()
    {
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }

    public void BugReport()
    {
        Application.OpenURL("https://forms.gle/A76Ywd26Xcc7iT849");
    }
}
