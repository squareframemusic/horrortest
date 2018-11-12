using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioMedicalTrolly : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        //if statement sets a gate to prevent smaller collisions from occurring.
        if (collision.relativeVelocity.magnitude > 0.50f)
        {
            AudioManager.instance.TrollyCollision(collision.relativeVelocity.magnitude, this.transform.position);
        }
    }
}
