using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

    /// <summary>
    /// 
	/// <Variables> 
    /// 
    /// public Transform variables : 'player' to hold the player component
    ///                              'respawn' to respawn the player after he dies to a given position
    ///                               
    /// public boolean variables : 'respawned' to check if the player respawned so he loses life
    /// 
    /// public static component variable : 'lifes' to get access to the PlayerMovement script
    /// 
    /// </summary>
    
        
    public Transform player;
    public Transform respawn;
    
    public static bool respawned;

    public static PlayerMovement lifes;
    
    

    // Use this for initialization
    void Start()
    {
        respawned = false;
        lifes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawn.transform.position;
        respawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        LevelManager.LifeManager();
    }
}
