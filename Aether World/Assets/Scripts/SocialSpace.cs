using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialSpace : MonoBehaviour
{

    public GameObject player;  //Stores player object refference
    Vector2 playerPosition;  //Used to store player position

    bool canUseLevelSelectionBoard = false;  //If player can interact with level selection board


    private void Update()
    {
        playerPosition = player.transform.position;  //Updates player position

        if (canUseLevelSelectionBoard == true)
        {
            //Go to level selection UI
            //Stop movement
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Function that runs when player enters a collider (with collider having trigger)
    {
        if (collision.name == "LevelSelectionBoard")  //If collider is named LevelSelectionBoard
        {
            canUseLevelSelectionBoard = true;  //Can use board
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //Function that runs when player exits a collider (with collider having trigger)
    {
        if (collision.name == "LevelSelectionBoard")
        {
            canUseLevelSelectionBoard = false;  //Cant use board
        }
    }
}
