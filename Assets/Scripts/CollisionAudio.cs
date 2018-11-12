using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour {

    public enum objectList
    {
        trolley,
        cup,
        hospitalBed
    }

    public objectList objectType;

    public void OnCollisionEnter(Collision collision)
    {
        //if statement sets a gate to prevent smaller collisions from occurring.
        if (collision.relativeVelocity.magnitude > 0.50f)
        {
            if (objectType == objectList.trolley)
            {
                Debug.Log("trolley collision called");
                AudioManager.instance.TrollyCollision(collision.relativeVelocity.magnitude, this.transform.position);
            }
            if (objectType == objectList.cup)
            {
                AudioManager.instance.CupCollision(collision.relativeVelocity.magnitude, this.transform.position);
            }
            if (objectType == objectList.hospitalBed)
            {
                AudioManager.instance.HospitalBedCollision(collision.relativeVelocity.magnitude, this.transform.position);
            }
        }
     
    }
}
