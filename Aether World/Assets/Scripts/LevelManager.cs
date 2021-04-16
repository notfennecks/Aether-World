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

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Respawn()
    {
        //Instantiate(player, RespwanPoint.position, Quaternion.identity);
        SceneManager.LoadScene("LevelSelection");
    }

    public void Victory()
    {
        SceneManager.LoadScene("LevelSelection");//There need to be something here to show the level was beaten, not just exited.
    }
}
