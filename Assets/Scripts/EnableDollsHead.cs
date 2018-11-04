using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDollsHead : MonoBehaviour {

    public GameObject dollHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        //enables the dolls head in front of the camera.
        dollHead.SetActive(true);
        Debug.Log("collided with doll head activator");
    }
}
