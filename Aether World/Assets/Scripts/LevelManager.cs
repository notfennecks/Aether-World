using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform RespwanPoint;
    private GameObject player;
    public GameObject GoalPoint;

    /*public struct level
    {
        bool victory;
        string SceneName;
    }*/

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        /*level Overworld1;
        Overworld1.victory = false;
        Overworld1.SceneName = SceneManager.GetSceneByName().name;*/
    }

    public void Respawn()
    {
        //Instantiate(player, RespwanPoint.position, Quaternion.identity);
        SceneManager.LoadScene("LevelSelection");
    }

    /*public void Victory()
    {
        public string levelname = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelSelection");//There need to be something here to show the level was beaten, not just exited.
    }*/
}
