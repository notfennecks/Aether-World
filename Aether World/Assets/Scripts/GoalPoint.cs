using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalPoint : MonoBehaviour
{
    //public static  LevelSelection LS;
    public string levelName;
    public LevelSelection LS;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VictoryLevel();
            //SceneManager.LoadScene("LevelSelection");
            //LevelManager.instance.Victory();
        }
    }
   
    public void VictoryLevel()
    {
        SceneManager.LoadScene("LevelSelection");
        LS.UpdateLevelStatus(levelName);
    }




}
