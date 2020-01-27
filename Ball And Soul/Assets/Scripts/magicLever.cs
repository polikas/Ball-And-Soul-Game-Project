using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicLever : MonoBehaviour {

    private int currentTarget;

    public float speed = 5f;
    public Transform[] target;
    public static bool collides;
    
	void Start()
    {
        collides = false;
    }


    void Update()
    {
        if (collides)
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
