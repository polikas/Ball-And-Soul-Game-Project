using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : MonoBehaviour {

    /// <summary>
    /// 
    /// <Variables>
    /// 
    /// private int variables : 'currentTarget' To store the current target 
    /// 
    /// public float variables : 'speed' to control the elevators movement speed which it can
    ///                          be changed from the inspector too
    /// 
    /// public Transform[] array : 'target' to hold and update the next movement of the elevators
    /// 
    /// </summary>

    private int currentTarget;
    public float speed = 5f;
    public Transform[] target;

    // Update is called once per frame
    void Update()
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
