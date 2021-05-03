using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalPoint : MonoBehaviour
{
    //public static  LevelSelection LS;
    public string levelName;
    public GameManager GameManager;
    //public LevelSelection LS;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //VictoryLevel();
            //SceneManager.LoadScene("LevelSelection");
            //LevelManager.instance.Victory();
            SceneManager.LoadScene("LevelSelection");
            GameManager.Victory(levelName);
        }
    }
   
    /*public void VictoryLevel()
    {
        SceneManager.LoadScene("LevelSelection");
        GM.Victory(levelName);
    }*/




}
