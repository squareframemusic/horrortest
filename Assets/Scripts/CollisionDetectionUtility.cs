using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionUtility : MonoBehaviour {

    public bool printCollisionMagnitude = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (printCollisionMagnitude == true)
        {
            //prints to console the magnitude between collider velocities i.e., force of impact.
            Debug.Log("collision magnitude = " + collision.relativeVelocity.magnitude);
        }
    }
}
