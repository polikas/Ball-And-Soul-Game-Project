using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBox : MonoBehaviour {

    /// <summary>
    /// 
    /// <Variables>
    /// 
    /// private int variables : 'currentTarget' To store the current target 
    /// 
    /// public float variables : 'speed' to control the elevators movement speed which it can
    ///                          be changed from the inspector too
    /// 
    /// public Transform[] array : 'target' to hold and update the next movement of the doors
    /// 
    /// </summary>

    private int currentTarget;
    public float speed = 5f;
    public Transform[] target;

    // Update is called once per frame
    void Update()
    {
        // Check if coins are 24 then move the magic box and execute the code
        if (PlayerMovement.count == 25)
        {
            // to move the magic elevator & open the doors
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
