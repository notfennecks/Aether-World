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
        Scoria2.SceneName = "Scoria02";
        Scoria3.complete = false;//establish default data for scoria

        Terra1.complete = false;
        Terra1.SceneName = "Terra01";
        Terra2.complete = false;
        Terra2.SceneName = "Terra02A";
        Terra3.complete = false;
        Terra3.SceneName = "Terra03";//establish default data for terra

        Zephyr1.complete = false;
        Zephyr1.SceneName = "Zephyr01";
        Zephyr2.complete = false;
        Zephyr2.SceneName = "Zephyr02";
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
        if(levelName.Contains("Overworld2"))
        {
            Overworld2.complete = true;
            Debug.Log("The player has beaten Overworld 2");
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
            FactionActivity("Scoria");
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
            FactionActivity("Zephyr");
        }

    }


    public void FactionActivity(string World)//this runs each time a NEW level (not the tutorial) was beaten
    {
        //LS = GameObject.Find("LevelSelection").GetComponent<LevelSelection>();
        switch (World)//this checks what world the latest level was beaten in
        {
            case "Overworld":
                Earth.PlayerOpinion += 4;//the earth faction likes when the player prioritizes defending their world over attacking others
                Earth.resources += 2;
                Water.PlayerOpinion += 2;
                Water.resources += 2;
                Fire.PlayerOpinion += 1;
                Fire.resources += 2;
                Air.PlayerOpinion -= 1;//the Air faction doesn't like when the player focuses on the overworld
                Air.resources += 2;
                break;
            case "Eldoris":
                Earth.PlayerOpinion += 1;
                Earth.resources += 2;
                Water.PlayerOpinion -= 4;//the Water faction is mostly harmed by the player completing one of their levels
                Water.resources -= 1;
                Fire.PlayerOpinion += 4;//the fire faction gets bonuses  instead
                Fire.resources += 4;
                Air.PlayerOpinion += 1;
                Air.resources += 2;
                break;
            case "Terra":
                Earth.PlayerOpinion -= 4;
                Earth.resources -= 1;
                Water.PlayerOpinion += 1;
                Water.resources += 2;
                Fire.PlayerOpinion += 3;//the fire faction gets a slight boost in resources when a terra level is attacked
                Fire.resources += 3;
                Air.PlayerOpinion += 4;//the Air faction gets a big boost as well
                Air.resources += 3;
                break;
            case "Scoria":
                Earth.PlayerOpinion += 2;
                Earth.resources += 3;
                Water.PlayerOpinion += 4;
                Water.resources += 3;
                Fire.PlayerOpinion -= 5;//the fire faction really doesn't like when the player completes one of their levels
                Fire.resources -= 1;
                Air.PlayerOpinion += 2;
                Air.resources += 2;
                break;
            case "Zephyr":
                Earth.PlayerOpinion += 3;//the earth faction doesn't get as big buffs as other factions do
                Earth.resources += 3;
                Water.PlayerOpinion += 1;
                Water.resources += 2;
                Fire.PlayerOpinion += 2;
                Fire.resources += 2;
                Air.PlayerOpinion -= 4;
                Air.resources -= 1;
                break;
            default:
                break;
        }
        if (Earth.defeated == true)//now we need to see if any of the factions are defeated (if their level 3 has been beaten)
        {
            Earth.PlayerOpinion = 0;
            Earth.resources = 0;
        }
        if (Water.defeated == true)
        {
            Water.PlayerOpinion = 0;
            Water.resources = 0;
        }
        if (Fire.defeated == true)
        {
            Fire.PlayerOpinion = 0;
            Fire.resources = 0;
        }
        if (Air.defeated == true)
        {
            Air.PlayerOpinion = 0;
            Air.resources = 0;
        }

        // Here is where the factions begin to change levels around
        // starting with the Earth faction
        if (Earth.defeated == false)//can't do anything if they've been defeated
        {
            if (Terra1.complete == false)//this is if the player has not beaten a single terra level yet
            {
                Earth.resources += 2;//The Earth faction does not want to provoke anyone yet, so they build up their own resources instead
                Debug.Log("The Earth faction is gathering resources");
            }
            else if (Terra1.complete == true)//this means the player beat at least the first Terra level
            {
                if (Terra2.complete == false)//this means ONLY the first Terra level has been completed
                {
                    /*if (Earth.PlayerOpinion <= 0)//this means the earths opinion of the player hit the negatives, or 0. 
                    {
                        Earth.PlayerOpinion = 0;
                        //IMPLEMENT LATER
                        //They are most likely going to attack the overworld
                    }*/
                    if (Earth.PlayerOpinion > 0 && Earth.PlayerOpinion <= 4)//this means they've been attacked, they will likely want to fortify themselves
                    {
                       
                        if (Earth.resources >= 5 && !Terra2.SceneName.Contains("Terra02B"))// they have some resources to spare
                        {
                            
                            Terra2.SceneName = "Terra02B";
                            Earth.resources -= 5;
                            Debug.Log("Terra2 has been fortified");
                        }
                        else if(Terra2.SceneName.Contains("Terra02C"))
                        {
                            Terra2.SceneName = "Terra02A";
                            Earth.resources -= 5;
                            Debug.Log("Terra2 has been secured by the Earth faction");
                        }
                        else
                        {
                            Earth.resources += 2;
                            Debug.Log("The Earth faction is gathering resources");
                        }

                    }
                    else if (Earth.PlayerOpinion > 4)// the first level has been beaten, but not recently
                    {
                       
                        
                        if(Earth.resources >= 7)
                        {
                            if(Air.resources >= Fire.resources)
                            {
                                Air.resources -= 5;
                                Earth.resources -= 7;
                                Debug.Log("The Earth faction has weakened the Air faction");
                            }
                            else
                            {
                                Fire.resources -= 6;
                                Earth.resources -= 6;
                                Debug.Log("The Earth faction has weakened the Fire faction");
                            }
                        }
                        
                        else if(Earth.resources >= 5 && Earth.resources < 7 && !Terra2.SceneName.Contains("Terra02B"))
                        {
                            Terra2.SceneName = "Terra02B";
                            Earth.resources -= 5;
                            Debug.Log("Terra2 has been fortified");
                        }
                       
                        else
                        {
                            Earth.resources += 2;
                            Debug.Log("The Earth faction is gathering resources");
                        }
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
        if (Water.defeated == false)//can't do anything if they've been defeated
        {
            if (Eldoris1.complete == false)//this is if the player has not beaten a single eldoris level yet
            {
                Fire.resources -= 2;//The Water faction will try to make sure the fire faction doesn't get an upper hand on them
                Debug.Log("The water faction has sabotaged the fire faction");
            }
            else if (Eldoris1.complete == true)//this means the player beat at least the first Eldoris level
            {
                if (Eldoris2.complete == false)//this means ONLY the first Eldoris level has been completed
                {
                   /* if (Water.PlayerOpinion <= 0)//this means the waters opinion of the player hit the negatives, or 0. 
                    {
                        Water.PlayerOpinion = 0;
                        //IMPLEMENT LATER
                        //They are most likely going to attack the overworld
                    }*/
                    if (Water.PlayerOpinion <= 5)//this means they've been attacked recently, they will likely strike back
                    {
                        //IMPLEMENT LATER
                        if (Water.resources >= 7 && !Overworld2.SceneName.Contains("Overworld02B"))// they have some resources to spare
                        {
                            //IMPLEMENT LATER
                            Overworld2.SceneName = "Overworld02B";
                            Water.resources -= 7;
                            Debug.Log("The water faction has invaded Overworld2");
                        }
                        else if (Water.resources >= 3 && Water.resources < 7 && !Eldoris2.SceneName.Contains("Eldoris02B"))//they dont have the resources to launch a counterattack
                        {
                            //IMPLEMENT LATER
                            Eldoris2.SceneName = "Eldoris02B";
                            Water.resources -= 3;
                            Debug.Log("the Water faction has fortified Eldoris2");
                        }
                        else
                        {
                            Water.PlayerOpinion += 1;
                            Water.resources += 1;
                            Debug.Log("The water faction is gaining resources and letting go of their grudge with the player");
                        }
                    }
                    else if (Water.PlayerOpinion > 5)// the first level has been beaten, but not recently
                    {
                        //IMPLEMENT LATER
                        if (Water.resources >= 3 && Water.resources < 7 && !Eldoris2.SceneName.Contains("Eldoris02B"))//they will use some resources to fortify
                        {
                            //IMPLEMENT LATER
                            Eldoris2.SceneName = "Eldoris02B";
                            Water.resources -= 3;
                            Debug.Log("the water faction has fortified Eldoris2");
                        }
                        //Otherwise they will go after the fire faction
                        else if(Water.resources >= 7)
                        {
                            //IMPLEMENT LATER
                            if(!Scoria2.SceneName.Contains("Scoria02B"))
                            {
                                Scoria2.SceneName = "Scoria02B";
                                Water.resources -= 7;
                                Debug.Log("The water faction has invaded Scoria2");
                            }
                            else
                            {
                                Water.resources -= 5;
                                Fire.resources -= 7;
                                Debug.Log("The Water faction has attacked the fire faction");
                            }
                        }
                        //If they can't do anything else, they will gain some resources
                        else
                        {
                            Water.resources += 1;
                            Debug.Log("The water faction is gathering resources");
                        }
                    }
                }
                else if (Eldoris2.complete == true)//this means both Eldoris 1 and 2 are completed
                {
                    if (Water.PlayerOpinion <= 5)//they've been attacked recently, and are down to their last level
                    {
                        //IMPLEMENT LATER
                        //they will panick and want to fortify themselves as much as possible
                    }
                    else if (Water.PlayerOpinion > 5)//they haven't been attacked recently
                    {
                        //IMPLEMENT LATER
                        //They realize they likely won't hold forever, instead opting to make a new foothold somewhere else 
                        //If those are both done they will weaken the fire faction
                    }

                }


            }
        }
        //This is for the Air faction
        if (Air.defeated == false)//can't do anything if they've been defeated
        {
            if (Zephyr1.complete == false)//this is if the player has not beaten a single zephyr level yet
            {
                Earth.resources -= 2;
                Fire.resources -= 1;//the Air faction likes to mess with the others, they're good at messing with the earth faction
                Debug.Log("The Air faction has sabotaged the Earth and Fire factions");
            }
            else if (Zephyr1.complete == true)//this means the player beat at least the first Zephyr level
            {
                if (Zephyr2.complete == false)//this means ONLY the first Zephyr level has been completed
                {
                    if (Air.PlayerOpinion <= 0)//this means the Airs opinion of the player hit the negatives, or 0. 
                    {
                        Air.PlayerOpinion = 6;
                        //IMPLEMENT LATER
                        Overworld2.SceneName = "Overworld02C";
                        Air.resources -= 7;//they can put themselves in the negatives for this
                        Debug.Log("The Air faction has invaded Overworld2");
                    }
                    else if (Air.PlayerOpinion > 0 && Air.PlayerOpinion <= 5)//this means they've been attacked recently, they will likely strike back
                    {
                        //IMPLEMENT LATER
                        if (Air.resources >= 7)// they have some resources to spare
                        {
                            //IMPLEMENT LATER
                            
                            if (AirE.unlocked == true)
                            {
                                AirE.unlocked = false;
                                pixieKilled = 0;
                                AirE.currentAmount = 0;
                                Air.resources -= 7;
                                Debug.Log("The Air faction has stolen the player's Air essence");
                            }
                            else if (AirE.unlocked == false && !Overworld2.SceneName.Contains("Overwolrd02C"))
                            {
                                Overworld2.SceneName = "Overworld02C";
                                Air.resources -= 7;
                                Debug.Log("The Air faction has invaded Overworld2");
                            }
                            
                            //or they will steal a different unlocked essence
                        }
                        else if (Air.resources >= 5 && Air.resources < 7)//they dont have the resources to mess with the player
                        {
                            //IMPLEMENT LATER
                            Zephyr2.SceneName = "Zephyr02B";
                            Air.resources -= 5;
                            Debug.Log("The Air faction has fortified Zephyr2");
                        }
                        else if (Air.resources < 5)// they will steal some energy from the player, gaining resources and making it harder for the player to unlock their essences
                        {
                            Air.resources += 1;
                            AirE.amountToUnlock += 1;
                            FireE.amountToUnlock += 1;
                            WaterE.amountToUnlock += 1;
                            EarthE.amountToUnlock += 1;
                            Debug.Log("The Air faction has sabotaged the player's essence system");
                        }
                    }
                    else if (Air.PlayerOpinion > 5)// the player has left them alone, they will leave the player alone for now
                    {
                        //IMPLEMENT LATER
                        if (Air.resources >= 7)//they will attack either the Earth or fire factions
                        {
                            //IMPLEMENT LATER
                            //make sure they do something different if both factions are defeated
                            if (Earth.resources >= Fire.resources)
                            {
                                if(Earth.resources >= 7)
                                {
                                    Air.resources -= 7;
                                    Earth.resources -= 7;
                                    Debug.Log("The Air faction has failed to invade the Earth Faction");
                                }
                                else if(Earth.resources < 7)
                                {
                                    if(Terra2.complete == false)
                                    {
                                        if(Terra2.SceneName.Contains("Terra02B"))
                                        {
                                            Terra2.SceneName = "Terra02";
                                            Earth.resources -= 2;
                                            Air.resources -= 7;
                                            Debug.Log("The Air faction has weakened the Earth factions defenses at Terra2");
                                        }
                                        else if(Terra2.SceneName.Contains("Terra02"))
                                        {
                                            Terra2.SceneName = "Terra02C";
                                            Earth.resources -= 3;
                                            Air.resources -= 5;
                                            Debug.Log("The Air faction has successfully invaded Terra2");
                                        }
                                        
                                    }
                                    else if(Terra2.complete == true)
                                    {
                                        //IMPLEMENT LATER
                                        //Terra3 is too strong even for the air faction to fully invade
                                    }
                                }
                            }
                            else if (Fire.resources > Earth.resources)
                            {
                                //IMPLEMENT LATER
                                //the air faction will attempt to invade the fire factions territory
                                if(Fire.resources >= 6)
                                {
                                    Air.resources -= 4;
                                    Fire.resources -= 5;
                                    Debug.Log("The Air faction has failed to invade the Fire faction");
                                }
                                else if (Fire.resources < 6)
                                {
                                    if (Scoria2.complete == false)
                                    {
                                        if (Scoria2.SceneName.Contains("Scoria02C"))
                                        {
                                            
                                            Fire.resources -= 5;
                                            Air.resources += 2;
                                            Debug.Log("The Air faction has siphoned resources from the Fire faction at Scoria2");
                                        }
                                        else
                                        {
                                            Scoria2.SceneName = "Scoria02C";
                                            Fire.resources -= 4;
                                            Air.resources -= 7;
                                            Debug.Log("The Air faction has successfully invaded Scoria2");
                                        }

                                    }
                                    else if (Scoria2.complete == true)
                                    {
                                        //IMPLEMENT LATER
                                        //Scoria3 is quite hot, the Air faction doesn't want to invade there
                                    }
                                }
                            }
                        }
                        else if(Air.resources < 7)
                        {
                            Water.resources -= 1;
                            Earth.resources -= 2;
                            Fire.resources -= 1;
                            Air.resources += 4;
                            Debug.Log("The Air faction has stolen resources from the other factions");
                        }
                       
                        //If they can't do anything else, they will prepare to attack the player
                    }
                }
                else if (Zephyr2.complete == true)//this means both Zephyr 1 and 2 are completed
                {
                    if (Air.PlayerOpinion <= 5)//they've been attacked by the player too much, now they're afraid
                    {
                        //IMPLEMENT LATER
                        //they will fortify their last level
                    }
                    else if (Air.PlayerOpinion > 5)//they haven't been attacked recently
                    {
                        //IMPLEMENT LATER
                        //They will continue their shenanigans, picking on the weaker faction
                        
                    }

                }

            }

        }
        //This last one is for the Fire faction
        if (Fire.defeated == false)//can't do anything if they've been defeated
        {
            if (Scoria1.complete == false)//this is if the player has not beaten a single scoria level yet
            {
                if(Water.resources >= Air.resources)
                {
                    if (Earth.resources > Water.resources)//if the Earth faction has the most resources
                    {
                        Earth.resources -= 3;
                        Fire.resources += 2;
                        Debug.Log("The Fire faction has sabotaged the Earth faction");
                    }
                    else if (Water.resources >= 8)//The water faction has the most, and its more than 8
                    {
                        if(Fire.resources >=6)//the fire faction attempts to attack the water faction, it doesn't go well
                        {
                            Fire.resources -= 6;
                            Water.resources -= 7;
                            Debug.Log("The Fire faction failed to invade the Water Faction");
                        }
                        else if(Fire.resources < 6)//the fire faction sabotages the water faction and makes them think the player did it
                        {
                            Fire.resources -= 3;
                            Water.PlayerOpinion -= 2;
                            WaterE.amountToUnlock -= 2;
                            Debug.Log("The Fire faction has sabotaged the Water faction, and made the player look guilty");
                        }
                    }
                    else if(Water.resources < 8)//the fire faction attempts to attack the water faction, they actually get a foothold if its eldoris 2
                    {
                        //IMPLEMENT LATER
                        if (Fire.resources >= 6)
                        {
                            if (Eldoris2.SceneName.Contains("Eldoris02B"))
                            {
                                Fire.resources -= 5;
                                Water.resources -= 5;
                                Eldoris2.SceneName = "Eldoris2";
                                Debug.Log("The Fire faction has weakened the Water factions defenses at Eldoris2");
                            }
                            else if(Eldoris2.SceneName.Contains("Eldoris02"))
                            {
                                Fire.resources -= 6;
                                Water.resources -= 7;
                                Eldoris2.SceneName = "Eldoris02C";
                                Debug.Log("The Fire faction has successfully invaded Eldoris2");
                            }
                        }
                        else if(Fire.resources < 6)
                        {
                            Fire.resources += 1;
                            Water.resources -= 2;
                            Debug.Log("The fire faction has weakened the Water Faction");
                        }
                    }

                }
                else if(Air.resources > Water.resources)
                {
                    if (Earth.resources > Water.resources)//if the Earth faction has the most resources
                    {
                        Earth.resources -= 3;
                        Fire.resources += 2;
                        Debug.Log("The Fire faction has sabotaged the Earth faction");
                    }
                    else if(Fire.resources >= 5 )//they will attack the Air faction
                    {
                        //IMPLEMENT LATER
                        if(Air.resources >= 8)
                        {
                            Fire.resources -= 5;
                            Air.resources -= 8;
                            Debug.Log("The Fire faction has failed to invade the Air faction");
                        }
                        else
                        {
                            if(Zephyr2.SceneName.Contains("Zephyr02C"))
                            {
                                Fire.resources += Air.resources;
                                Air.resources = 0;
                                Debug.Log("The Fire faction has stolen all of the Air factions resources");
                            }
                            else if(Zephyr2.SceneName.Contains("Zephyr02B"))
                            {
                                Zephyr2.SceneName = "Zephyr02";
                                Fire.resources -= 3;
                                Air.resources -= 5;
                                Debug.Log("The fire faction has destroyed the Air factions defenses at Zephyr2");
                            }
                            else if(Zephyr2.SceneName.Contains("Zephyr02"))
                            {
                                Zephyr2.SceneName = "Zephyr02C";
                                Fire.resources -= 1;
                                Air.resources -= 6;
                                Debug.Log("The fire faction has invaded Zephyr2");
                            }
                        }
                    }
                    else
                    {
                        Fire.resources += 3;
                        Fire.PlayerOpinion -= 1;
                        Debug.Log("The fire faction is preparing to attack");
                    }

                }
            }
            else if (Scoria1.complete == true)//this means the player beat at least the first Scoria level
            {
                if (Scoria2.complete == false)//this means ONLY the first Scoria level has been completed
                {
                    if (Fire.PlayerOpinion <= 0)//this means the Fires opinion of the player hit the negatives, or 0. 
                    {
                       
                        //IMPLEMENT LATER
                        //They attack the overworld
                        Overworld2.SceneName = "Overworld02D";
                        Fire.resources -= 5;//they can put themselves in the negatives for this
                        Debug.Log("The Fire faction has invaded Overworld2");
                    }
                    else if (Fire.PlayerOpinion > 0 && Fire.PlayerOpinion <= 6)//this means they've been attacked recently, they will strike back
                    {
                        //IMPLEMENT LATER
                        if (Fire.resources >= 5)// they have some resources to spare
                        {
                            //IMPLEMENT LATER
                            //they will attack the overworld first, otherwise they will go for one of the other factions
                            if(!Overworld2.SceneName.Contains("Overworld02D"))
                            {
                                Overworld2.SceneName = "Overworld02D";
                                Fire.resources -= 5;
                                Debug.Log("The Fire faction has invaded Overworld2");
                            }
                            else
                            {
                                if (Water.resources >= Air.resources)
                                {
                                    if (Earth.resources > Water.resources)//if the Earth faction has the most resources
                                    {
                                        Earth.resources -= 3;
                                        Fire.resources += 2;
                                        Debug.Log("The Fire faction has sabotaged the Earth faction");
                                    }
                                    else if (Water.resources >= 8)//The water faction has the most, and its more than 8
                                    {
                                        if (Fire.resources >= 6)//the fire faction attempts to attack the water faction, it doesn't go well
                                        {
                                            Fire.resources -= 6;
                                            Water.resources -= 7;
                                            Debug.Log("The Fire faction failed to invade the Water Faction");
                                        }
                                        else if (Fire.resources < 6)//the fire faction sabotages the water faction and makes them think the player did it
                                        {
                                            Fire.resources -= 3;
                                            Water.PlayerOpinion -= 2;
                                            WaterE.amountToUnlock -= 2;
                                            Debug.Log("The Fire faction has sabotaged the Water faction, and made the player look guilty");
                                        }
                                    }
                                    else if (Water.resources < 8)//the fire faction attempts to attack the water faction, they actually get a foothold if its eldoris 2
                                    {
                                        //IMPLEMENT LATER
                                        if (Fire.resources >= 6)
                                        {
                                            if (Eldoris2.SceneName.Contains("Eldoris02B"))
                                            {
                                                Fire.resources -= 5;
                                                Water.resources -= 5;
                                                Eldoris2.SceneName = "Eldoris2";
                                                Debug.Log("The Fire faction has weakened the Water factions defenses at Eldoris2");
                                            }
                                            else if (Eldoris2.SceneName.Contains("Eldoris02"))
                                            {
                                                Fire.resources -= 6;
                                                Water.resources -= 7;
                                                Eldoris2.SceneName = "Eldoris02C";
                                                Debug.Log("The Fire faction has successfully invaded Eldoris2");
                                            }
                                        }
                                        else if (Fire.resources < 6)
                                        {
                                            Fire.resources += 1;
                                            Water.resources -= 2;
                                            Debug.Log("The fire faction has weakened the Water Faction");
                                        }
                                    }

                                }
                                else if (Air.resources > Water.resources)
                                {
                                    if (Earth.resources > Water.resources)//if the Earth faction has the most resources
                                    {
                                        Earth.resources -= 3;
                                        Fire.resources += 2;
                                        Debug.Log("The Fire faction has sabotaged the Earth faction");
                                    }
                                    else if (Fire.resources >= 5)//they will attack the Air faction
                                    {
                                        //IMPLEMENT LATER
                                        if (Air.resources >= 8)
                                        {
                                            Fire.resources -= 5;
                                            Air.resources -= 8;
                                            Debug.Log("The Fire faction has failed to invade the Air faction");
                                        }
                                        else
                                        {
                                            if (Zephyr2.SceneName.Contains("Zephyr02C"))
                                            {
                                                Fire.resources += Air.resources;
                                                Air.resources = 0;
                                                Debug.Log("The Fire faction has stolen all of the Air factions resources");
                                            }
                                            else if (Zephyr2.SceneName.Contains("Zephyr02B"))
                                            {
                                                Zephyr2.SceneName = "Zephyr02";
                                                Fire.resources -= 3;
                                                Air.resources -= 5;
                                                Debug.Log("The fire faction has destroyed the Air factions defenses at Zephyr2");
                                            }
                                            else if (Zephyr2.SceneName.Contains("Zephyr02"))
                                            {
                                                Zephyr2.SceneName = "Zephyr02C";
                                                Fire.resources -= 1;
                                                Air.resources -= 6;
                                                Debug.Log("The fire faction has invaded Zephyr2");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Fire.resources += 3;
                                        Fire.PlayerOpinion -= 1;
                                        Debug.Log("The fire faction is preparing to attack");
                                    }

                                }
                            }

                            
                        }
                        else if (Fire.resources >= 3 && Fire.resources < 5)//they dont have the resources to invade anywhere
                        {
                            //IMPLEMENT LATER
                            //they will take resources from whichever faction has the least
                            if(Water.resources <= Air.resources)
                            {
                                if(Water.resources <= Earth.resources)
                                {
                                    Water.resources -= 4;
                                    Fire.resources += 3;
                                    Debug.Log("The fire faction has stolen from the water faction");
                                }
                                else 
                                {
                                    Earth.resources -= 3;
                                    Fire.resources += 3;
                                    Debug.Log("The fire faction has stolen from the Earth faction");
                                }
                            }
                            else if(Air.resources <= Earth.resources)
                            {
                                Air.resources -= 3;
                                Fire.resources += 3;
                                Debug.Log("The fire faction has stolen from the Air faction");
                            }
                            else
                            {
                                Earth.resources -= 3;
                                Fire.resources += 3;
                                Debug.Log("The fire faction has stolen from the Earth faction");
                            }
                        }
                       
                    }
                    else if (Fire.PlayerOpinion > 6)// the player has left them alone, they will leave the player alone for now
                    {
                        //IMPLEMENT LATER
                        if (Fire.resources >= 7)//they will attack either the Water or Air factions
                        {
                            //IMPLEMENT LATER
                            //make sure they do something different if both factions are defeated
                            if (Water.resources >= Air.resources)
                            {
                                if (Water.resources >= 7)//the fire faction attacks the water faction, but they fail
                                {
                                    Fire.resources -= 5;
                                    Water.resources -= 7;
                                    Debug.Log("The Fire faction failed to invade the Water Faction");
                                }
                                else if (Water.resources < 7)//this time they might succeed
                                {
                                    if (Eldoris2.complete == false)
                                    {
                                        if (Eldoris2.SceneName.Contains("Eldoris02B"))
                                        {
                                            Eldoris2.SceneName = "Eldoris02";
                                            Water.resources -= 3;
                                            Fire.resources += 1;
                                            Debug.Log("The Fire faction has weakened the Air factions defenses at Eldoris2");
                                        }
                                        else if (Eldoris2.SceneName.Contains("Eldoris02"))
                                        {
                                            //IMPLEMENT LATER
                                            Fire.resources -= 6;
                                            Water.resources -= 7;
                                            Eldoris2.SceneName = "Eldoris02C";
                                            Debug.Log("The Fire faction has successfully invaded Eldoris2");
                                        }

                                    }
                                    else if (Eldoris2.complete == true)
                                    {
                                        //IMPLEMENT LATER
                                        //Eldoris3 is stronger, but that doesn't mean the fire faction can't break through
                                    }
                                }
                            }
                            else if (Air.resources > Water.resources)
                            {
                                //IMPLEMENT LATER
                                
                                if (Fire.resources >= 5)//they will attack the Air faction
                                {
                                    //IMPLEMENT LATER
                                    if (Air.resources >= 8)
                                    {
                                        Fire.resources -= 5;
                                        Air.resources -= 8;
                                        Debug.Log("The Fire faction has failed to invade the Air faction");
                                    }
                                    else
                                    {
                                        if (Zephyr2.SceneName.Contains("Zephyr02C"))
                                        {
                                            Fire.resources += Air.resources;
                                            Air.resources = 0;
                                            Debug.Log("The Fire faction has stolen all of the Air factions resources");
                                        }
                                        else if (Zephyr2.SceneName.Contains("Zephyr02B"))
                                        {
                                            Zephyr2.SceneName = "Zephyr02";
                                            Fire.resources -= 3;
                                            Air.resources -= 5;
                                            Debug.Log("The fire faction has destroyed the Air factions defenses at Zephyr2");
                                        }
                                        else if (Zephyr2.SceneName.Contains("Zephyr02"))
                                        {
                                            Zephyr2.SceneName = "Zephyr02C";
                                            Fire.resources -= 1;
                                            Air.resources -= 6;
                                            Debug.Log("The fire faction has invaded Zephyr2");
                                        }
                                    }
                                }
                                else
                                {
                                    Fire.resources += 3;
                                    Fire.PlayerOpinion -= 1;
                                    Debug.Log("The fire faction is preparing to attack");
                                }
                            }
                        }
                        else
                        {
                            Fire.resources += 3;
                            Fire.PlayerOpinion -= 1;
                            Debug.Log("The fire faction is preparing to attack");
                        }
                        
                    }
                }
                else if (Scoria2.complete == true)//this means both Scoria 1 and 2 are completed
                {
                    if (Fire.PlayerOpinion <= 5)//they've been attacked by the player alot, maybe they should rethink their approach
                    {
                        //IMPLEMENT LATER
                        //they will fortify their last level
                    }
                    else if (Air.PlayerOpinion > 5)//they haven't been attacked recently
                    {
                        //IMPLEMENT LATER
                        //They will continue their attacks, destroying any threat to their power

                    }

                }

            }

        }
    }
}
