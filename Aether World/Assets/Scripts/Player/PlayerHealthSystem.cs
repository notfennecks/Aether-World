using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)//this is the player death
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Destroy(gameObject);
            //LevelManager.instance.Respawn();
            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(currentScene.name);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            //LevelManager.instance.Respawn();
        }
    }

}
