using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicLever4 : MonoBehaviour {

    private int currentTarget;

    public float speed = 5f;
    public Transform[] target;
    public static bool collides4;

    // Use this for initialization
    void Start () {
        collides4 = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (collides4)
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
