using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {

    public GameObject player;
    public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        //Rotates the player to look at the door.
        //        player.transform.LookAt(door.transform.position);
        player.transform.rotation = Quaternion.LookRotation(door.transform.position);
        Debug.Log("player rotation called");
    }
}
