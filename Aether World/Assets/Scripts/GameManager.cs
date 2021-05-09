using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private LevelSelection LS;
    private GoalPoint GP;

    public int pixieKilled = 0;
    public int ajivaKilled = 0;
    public int deepKilled = 0;
    public int burningKilled = 0;

    public struct essence
    {
        public bool unlocked;
        public int amountToUnlock;
        public int currentAmount;
    }

    public essence AirE;
    public essence WaterE;
    public essence EarthE;
    public essence FireE;

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

    public struct faction
    {
        public int resources;
        public int PlayerOpinion;
        public bool defeated;
    };

    public faction Earth;
    public faction Air;
    public faction Water;
    public faction Fire;


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

        //Get a component reference to the attached LevelManager script

        AirE.unlocked = false;
        AirE.amountToUnlock = 5;
        EarthE.unlocked = false;
        EarthE.amountToUnlock = 5;
        WaterE.unlocked = false;
        WaterE.amountToUnlock = 5;
        FireE.unlocked = false;
        FireE.amountToUnlock = 5;
        


    }

    private void Update()
    {
        AirE.currentAmount = pixieKilled;
        EarthE.currentAmount = ajivaKilled;
        WaterE.currentAmount = deepKilled;
        FireE.currentAmount = burningKilled;

        if (AirE.currentAmount == AirE.amountToUnlock)
        {
            AirE.unlocked = true;
        }
        if (EarthE.currentAmount == EarthE.amountToUnlock)
        {
            EarthE.unlocked = true;
        }
        if (WaterE.currentAmount == WaterE.amountToUnlock)
        {
            WaterE.unlocked = true;
        }
        if (FireE.currentAmount ==FireE.amountToUnlock)
        {
            FireE.unlocked = true;
        }
    }

    private void Start()
    {
       
        Tutorial.complete = false;
        Tutorial.SceneName = "Level00";//establish the data for the tutorial level

        Overworld1.complete = false;
        Overworld1.SceneName = "Overworld01";
        Overworld2.complete = false;
        Overworld2.SceneName = "Overworld02";
        Overworld3.complete = false;//establish the default data for the overworld

        Eldoris1.complete = false;
        Eldoris1.SceneName = "Eldoris01";
        Eldoris2.complete = false;
        Eldoris2.SceneName = "Eldoris02";
        Eldoris3.complete = false;//establish the default data for eldoris

        Scoria1.complete = false;
        Scoria1.SceneName = "Scoria01";
        Scoria2.complete = false;
        Scoria3.complete = false;//establish default data for scoria

        Terra1.complete = false;
        Terra1.SceneName = "Terra01";
        Terra2.complete = false;
        Terra2.SceneName = "Terra02";
        Terra3.complete = false;
        Terra3.SceneName = "Terra03";//establish default data for terra

        Zephyr1.complete = false;
        Zephyr1.SceneName = "Zephyr01";
        Zephyr2.complete = false;
        Zephyr3.complete = false;//establish default data for zephyr

        Earth.PlayerOpinion = 8;//sets all the factions starting opinions of the player. Helps determine what they will do.
        Water.PlayerOpinion = 8;
        Fire.PlayerOpinion = 5;
        Air.PlayerOpinion = 6;
        Earth.resources = 10;//sets all the factions starting resources
        Water.resources = 10;
        Fire.resources = 10;
        Air.resources = 10;
        Earth.defeated = false;//sets all the factions to not be defeated, more on this later
        Water.defeated = false;
        Fire.defeated = false;
        Air.defeated = false;

    }


   

    public void Victory(string levelName)//this runs each time the player hits a goal point
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
            FactionActivity("Overworld");
        }
        if (levelName.Contains("Eldoris1"))
        {
            Eldoris1.complete = true;
            Debug.Log("The player has beaten Eldoris 1");
            FactionActivity("Eldoris");
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
            FactionActivity("Terra");
        }
        if (levelName.Contains("Zephyr1"))
        {
            Zephyr1.complete = true;
            Debug.Log("The player has beaten Zephyr 1");
        }

    }


    public void FactionActivity(string World)//this runs each time a NEW level (not the tutorial) was beaten
    {
        //LS = GameObject.Find("LevelSelection").GetComponent<LevelSelection>();
        switch (World)//this checks what world the latest level was beaten in
        {
            case "Overworld":
                Earth.PlayerOpinion += 5;//the earth faction likes when the player prioritizes defending their world over attacking others
                Earth.resources += 2;
                Water.PlayerOpinion += 3;
                Water.resources += 2;
                Fire.PlayerOpinion += 2;
                Fire.resources += 2;
                Air.PlayerOpinion -= 1;//the Air faction doesn't like when the player focuses on the overworld
                Air.resources += 2;
                break;
            case "Eldoris":
                Earth.PlayerOpinion += 1;
                Earth.resources += 2;
                Water.PlayerOpinion -= 4;//the Water faction is mostly harmed by the player completing one of their levels
                Water.resources += 1;
                Fire.PlayerOpinion += 5;//the fire faction gets bonuses  instead
                Fire.resources += 4;
                Air.PlayerOpinion += 1;
                Air.resources += 2;
                break;
            case "Terra":
                Earth.PlayerOpinion -= 4;
                Earth.resources += 1;
                Water.PlayerOpinion += 2;
                Water.resources += 2;
                Fire.PlayerOpinion += 3;//the fire faction gets a slight boost in resources when a terra level is attacked
                Fire.resources += 3;
                Air.PlayerOpinion += 5;//the Air faction gets a big boost as well
                Air.resources += 3;
                break;
            case "Scoria":
                Earth.PlayerOpinion += 3;
                Earth.resources += 3;
                Water.PlayerOpinion += 4;
                Water.resources += 3;
                Fire.PlayerOpinion -= 5;//the fire faction really doesn't like when the player completes one of their levels
                Fire.resources += 1;
                Air.PlayerOpinion += 3;
                Air.resources += 2;
                break;
            case "Zephyr":
                Earth.PlayerOpinion += 3;//the earth faction doesn't get as big buffs as other factions do
                Earth.resources += 3;
                Water.PlayerOpinion += 2;
                Water.resources += 2;
                Fire.PlayerOpinion += 3;
                Fire.resources += 2;
                Air.PlayerOpinion -= 4;
                Air.resources += 1;
                break;
            default:
                break;
        }
        if(Earth.defeated == true)//now we need to see if any of the factions are defeated (if their level 3 has been beaten)
        {
            Earth.PlayerOpinion = 0;
            Earth.resources = 0;
        }
        if(Water.defeated == true)
        {
            Water.PlayerOpinion = 0;
            Water.resources = 0;
        }
        if(Fire.defeated == true)
        {
            Fire.PlayerOpinion = 0;
            Fire.resources = 0;
        }
        if(Air.defeated == true)
        {
            Air.PlayerOpinion = 0;
            Air.resources = 0;
        }

        // Here is where the factions begin to change levels around
        // starting with the Earth faction
        if(Earth.defeated == false)//can't do anything if they've been defeated
        { 
            if(Terra1.complete == false)//this is if the player has not beaten a single terra level yet
            {
                Earth.resources += 2;//The Earth faction does not want to provoke anyone yet, so they build up their own resources instead
            }
            else if(Terra1.complete == true)//this means the player beat at least the first Terra level
            {
                if (Terra2.complete == false)//this means ONLY the first Terra level has been completed
                {
                    if (Earth.PlayerOpinion <= 0)//this means the earths opinion of the player hit the negatives, or 0. 
                    {
                        Earth.PlayerOpinion = 0;
                        //IMPLEMENT LATER
                        //They are most likely going to attack the overworld
                    }
                    else if (Earth.PlayerOpinion > 0 && Earth.PlayerOpinion <= 4)//this means they've been attacked, they will likely want to fortify themselves
                    {
                        //IMPLEMENT LATER
                        if (Earth.resources >= 5)// they have some resources to spare
                        {
                            //IMPLEMENT LATER
                            Terra2.SceneName = "Terra02B";
                            Earth.resources -= 5;
                            Debug.Log("Terra2 has changed to Terra2B");
                        }

                    }
                    else if (Earth.PlayerOpinion > 4)// the first level has been beaten, but not recently
                    {
                        //IMPLEMENT LATER
                        //They will prioritize weakening the Air or fire faction if they have resources to spare
                        //Otherwise they will fortify themselves if they haven't already
                        //If they can't do anything else, they will gain some resources
                    }
                }
                else if (Terra2.complete == true)//this means both Terra 1 and 2 are completed
                {
                    if (Earth.PlayerOpinion <= 4)//they've been attacked recently, and are down to their last level
                    {
                        //IMPLEMENT LATER
                        //they will make sure they are fortified first, otherwise they will attack the overworld
                    }
                    else if (Earth.PlayerOpinion > 4)//they haven't been attacked recently
                    {
                        //IMPLEMENT LATER
                        //they want to fortify themselves, they can have two levels of fortification (Terra3B and 3C)
                        //If those are both done they will weaken the Air or fire faction, depending on which is stronger
                    }

                }


            }
        }
        // This is for the Water faction
        if(Water.defeated == false)//can't do anything if they've been defeated
        { 
            if(Eldoris1.complete == false)//this is if the player has not beaten a single eldoris level yet
            {
                Fire.resources -= 2;//The Water faction will try to make sure the fire faction doesn't get an upper hand on them
            }
            else if(Eldoris1.complete == true)//this means the player beat at least the first Eldoris level
            {
                if (Eldoris2.complete == false)//this means ONLY the first Eldoris level has been completed
                {
                    if (Water.PlayerOpinion <= 0)//this means the waters opinion of the player hit the negatives, or 0. 
                    {
                        Earth.PlayerOpinion = 0;
                        //IMPLEMENT LATER
                        //They are most likely going to attack the overworld
                    }
                    else if (Water.PlayerOpinion > 0 && Water.PlayerOpinion <= 5)//this means they've been attacked recently, they will likely strike back
                    {
                        //IMPLEMENT LATER
                        if (Water.resources >= 7)// they have some resources to spare
                        {
                            //IMPLEMENT LATER
                            Overworld2.SceneName = "Overworld02B";
                            Water.resources -= 7;
                            Debug.Log("Overworld2 has changed to Overworld2B");
                        }
                        else if(Water.resources >= 3 && Water.resources < 7)//they dont have the resources to launch a counterattack
                        {
                            //IMPLEMENT LATER
                            Eldoris2.SceneName = "Eldoris02B";
                            Water.resources -= 3;
                            Debug.Log("Eldoris2 has changed to Eldoris2B");
                        }
                    }
                    else if (Water.PlayerOpinion > 5)// the first level has been beaten, but not recently
                    {
                        //IMPLEMENT LATER
                        if (Water.resources >= 3 && Water.resources < 7)//they will use some resources to fortify
                        {
                            //IMPLEMENT LATER
                            Eldoris2.SceneName = "Eldoris02B";
                            Water.resources -= 3;
                            Debug.Log("Eldoris2 has changed to Eldoris2B");
                        }
                        //Otherwise they will go after the fire faction
                        //If they can't do anything else, they will gain some resources
                    }
                }
                else if (Eldoris2.complete == true)//this means both Eldoris 1 and 2 are completed
                {
                    if (Water.PlayerOpinion <= 5)//they've been attacked recently, and are down to their last level
                    {
                        //IMPLEMENT LATER
                        //they will panick and want to fortify themselves as much as possible
                    }
                    else if (Water.PlayerOpinion > 4)//they haven't been attacked recently
                    {
                        //IMPLEMENT LATER
                        //They realize they likely won't hold forever, instead opting to make a new foothold somewhere else 
                        //If those are both done they will weaken the fire faction
                    }

                }


            }
        }

}


}
