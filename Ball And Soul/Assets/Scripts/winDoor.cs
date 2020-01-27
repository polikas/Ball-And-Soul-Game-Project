using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winDoor : MonoBehaviour {


    public Rigidbody rb;
    public static bool close;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        close = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (close)
        {
            rb.isKinematic = false;
        }
        
    }
}
