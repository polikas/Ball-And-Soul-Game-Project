using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    /// <summary>
    /// 
    /// <Variables>
    /// 
    /// private Rigidbody      : 'rb' To get the physics for the player
    /// 
    /// public float variables : 'currentHealth' to store and hold the HP of the player
    ///                          'jump' to give force to the Y axis so the player jumps
    ///                          'speed' to control the movement speed of the player
    ///        Text variables  : 'countCoins' to store and display the value of the coins
    ///        Text            : 'winText' An alert message to inform the player
    ///        
    ///      boolean variables : 'isGrounded' To check if the player collides with the floor 
    ///                                         this will help to develop the code for jump
    /// 
    ///      
    /// public Transform[] array : 'target' to hold and update the next movement of the elevators
    /// 
    /// </summary>

    private Rigidbody rb;
    public static int count;
    public int currentHealth;

    public float jump = 5f;
    public float speed = 5f;
    public Text countCoins;
    public Text winText;
    public AudioSource coinSound;

    public bool isGrounded;




    // Use this for initialization
    void Start()
    {
        // Give our sphere(player) physics
        rb = GetComponent<Rigidbody>();
        // Set coins value to 0
        count = 0;
        LevelManager.SetCountCoins();
        winText.text = "";
        // set the value to true
        isGrounded = true;
        // set the value of HP to maximum 5
        currentHealth = 5;
    }

 

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce(movement);
        if ((isGrounded) && (Input.GetKey(KeyCode.Space)))
        {
            rb.AddForce(Vector3.up * jump);
            // set the value to false so the player can not jump multiple times
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            coinSound.Play();
            LevelManager.SetCountCoins();
        }
    }

    /* check if the player is collides with the floor and then allow him to jump again
     * by setting the value of the variable isGrounded to true;
    */
    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Ground")) && (isGrounded == false))
        {
            isGrounded = true;
        }
        else if ((other.gameObject.CompareTag("magicGround")) && (isGrounded == false))
        {
            winText.text = " ";
            isGrounded = true;
        }
        else if ((other.gameObject.CompareTag("MagicLever")) && (magicLever.collides == false))
        {
            magicLever.collides = true;
        }
        else if ((other.gameObject.CompareTag("MagicLever2")) && (magicLever2.collides2 == false))
        {
            magicLever2.collides2 = true;
        }
        else if ((other.gameObject.CompareTag("MagicLever3")) && (magicLever3.collides3 == false))
        {
            magicLever3.collides3 = true;
        }
        else if ((other.gameObject.CompareTag("MagicLever4")) && (magicLever4.collides4 == false))
        {
            magicLever4.collides4 = true;
        }
        else if (other.gameObject.CompareTag("DangerArea"))
        {
            isGrounded = false;
            winText.text = "IN THIS AREA YOU CAN'T JUMP";
        }
        else if (other.gameObject.CompareTag("Ring"))
        {
            winText.text = "FOLLOW THE ROTATION AND JUMP";
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("AfterRing"))
        {
            winText.text = " ";
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("HunterArea"))
        {
            winText.text = "JUMP TO DODGE THE HUNTER";
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("PuzzleArea"))
        {
            winText.text = "YOU MUST..";
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("RightMyLove"))
        {
            winText.text = "RIGHT.. RIGHT IS FASTER";
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("WinArea"))
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (other.gameObject.CompareTag("Airship"))
        {
            AirshipController.checker = true;
            winDoor.close = true;
            isGrounded = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("DangerArea"))
        {
            isGrounded = true;
            winText.text = " ";
        }
        else if (other.gameObject.CompareTag("HunterArea"))
        {
            winText.text = " ";
        }
        else if (other.gameObject.CompareTag("RightMyLove"))
        {
            winText.text = " ";
        }
    }
}
