using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /// <summary>
    /// 
    /// private static variables : countC to store our coins value from the PlayerMovement script
    ///                            winMessage to store our door trigger value from the PlayerMovement script
    ///                            player to store the components of our player from the PlayerMovement script
    /// </summary>
    private static PlayerMovement countC;
    private static PlayerMovement winMessage;
    private static PlayerMovement player;

    void Start()
    {
        // A reference for the coins to get the components of the player
        countC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        // A reference for the door trigger message to get the components of the player
        winMessage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        // A reference for the player to get the components of the player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // A function to update the value of coins
    public static void SetCountCoins()
    {
        countC.countCoins.text = "Coins " + PlayerMovement.count.ToString() + "/33";
        if (PlayerMovement.count == 22)
        {
            winMessage.winText.text = "SOMETHING MOVES!";
        }
    }

    //A trigger function to clear the text
    private void OnTriggerEnter(Collider player)
    {
        player.gameObject.CompareTag("magicGround");
        
    }

    //A coroutine to wait three seconds to load HighScore scene
    IEnumerator WaitThree()
    {
        yield return new WaitForSeconds(3);
    }

    IEnumerator LoadScoreScene()
    {
        yield return StartCoroutine("WaitThree");
    }

    // A method to load HighScore scene
    public static void LoadScore()
    {
        SceneManager.LoadScene("LoseScene");
    }

    // A method to manipulate the lifes if the player dies
    public static void LifeManager()
    {
        if (RespawnTrigger.respawned)
        {
            RespawnTrigger.lifes.currentHealth--;
            RespawnTrigger.respawned = false;
        }
        if (RespawnTrigger.lifes.currentHealth <= 0)
        {
            LoadScore();
        }
    }
}
