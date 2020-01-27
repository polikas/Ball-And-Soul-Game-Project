using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicLever3 : MonoBehaviour {

    private int currentTarget;

    public float speed = 5f;
    public Transform[] target;
    public static bool collides3;

    // Use this for initialization
    void Start () {
        collides3 = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (collides3)
        {
            if (transform.position != target[currentTarget].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[currentTarget].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                currentTarget = (currentTarget + 1) % target.Length;
            }
        }
    }
}
