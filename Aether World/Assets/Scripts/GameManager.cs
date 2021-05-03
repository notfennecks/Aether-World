using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private LevelSelection LS;
    private GoalPoint GP;

    public struct level
    {
        public bool complete;
        public string SceneName;
    };

    public level Tutorial;
    public level Overworld1;
    public level Overworld2;
    public level Overworld3;
    public level Eldoris1;
    public level Eldoris2;
    public level Eldoris3;
    public level Scoria1;
    public level Scoria2;
    public level Scoria3;
    public level Terra1;
    public level Terra2;
    public level Terra3;
    public level Zephyr1;
    public level Zephyr2;
    public level Zephyr3;



    private void Awake()
    {
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            //Debug.Log("Game manager set up");
        }
        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        LS = GetComponent<LevelSelection>();


    }

    private void Start()
    {
       
        Tutorial.complete = false;
        Tutorial.SceneName = "Level00";
        Overworld1.complete = false;
        Overworld1.SceneName = "Overworld01";
        Eldoris1.complete = false;
        Eldoris1.SceneName = "Eldoris01";
        Scoria1.complete = false;
        Scoria1.SceneName = "Scoria01";
        Terra1.complete = false;
        Terra1.SceneName = "Terra01";
        Zephyr1.complete = false;
        Zephyr1.SceneName = "Zephyr01";



    }


   

    public void Victory(string levelName)
    {
        if (levelName.Contains("Tutorial"))
        {
            Tutorial.complete = true;
            Debug.Log("The tutorial has been completed");
        }
        if (levelName.Contains("Overworld1"))
        {
            Overworld1.complete = true;
            Debug.Log("The player has beaten Overworld 1");
        }
        if (levelName.Contains("Eldoris1"))
        {
            Eldoris1.complete = true;
            Debug.Log("The player has beaten Eldoris 1");
        }
        if (levelName.Contains("Scoria1"))
        {
            Scoria1.complete = true;
            Debug.Log("The player has beaten Scoria 1");
        }
        if (levelName.Contains("Terra1"))
        {
            Terra1.complete = true;
            Debug.Log("The player has beaten Terra 1");
        }
        if (levelName.Contains("Zephyr1"))
        {
            Zephyr1.complete = true;
            Debug.Log("The player has beaten Zephyr 1");
        }

    }



}
