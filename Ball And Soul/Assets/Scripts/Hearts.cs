using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour {
    /// <summary>
    /// An array to store the lifes
    /// </summary>

    public Sprite[] LifeSprite;

    public Image LifeUI;

    private PlayerMovement player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeUI.sprite = LifeSprite[player.currentHealth];
    }
}
