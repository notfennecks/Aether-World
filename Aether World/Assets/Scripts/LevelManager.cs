using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform RespwanPoint;
    public GameObject PlayerPrefab;
    public GameObject GoalPoint;

    private void Awake()
    {
        instance = this;
    }
    public void Respawn()
    {
        Instantiate(PlayerPrefab, RespwanPoint.position, Quaternion.identity);
    }

    public void Victory()
    {
        SceneManager.LoadScene("LevelSelection");//There need to be something here to show the level was beaten, not just exited.
    }
}
