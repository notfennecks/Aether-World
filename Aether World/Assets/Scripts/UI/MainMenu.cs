using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //We would either want this to go to social space or level selection
        //I recommend social space so you talk to npc before loading a level
        SceneManager.LoadScene("Level00");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit!");
            Application.Quit();
        }
    }
}
