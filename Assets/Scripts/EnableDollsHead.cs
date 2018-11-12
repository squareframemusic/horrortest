using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDollsHead : MonoBehaviour {

    public GameObject dollHead;
    public GameObject character;
    public GameObject endDestination;
    public GameObject logo;

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

        //turns on glitchy camera effect.
        GameObject.Find("FirstPersonCharacter").GetComponent<GlitchEffect>().enabled = true;

        StartCoroutine(EndGame());

        Debug.Log("collided with doll head activator");
    }

    IEnumerator EndGame()
    {
        //waits for this amount of time.
        yield return new WaitForSeconds(1f);

        //turns off the dolls head.
        dollHead.SetActive(false);

        //moves player to end of game prison.
        character.transform.position = endDestination.transform.position;

        //turns off glitchy visual effect.
        GameObject.Find("FirstPersonCharacter").GetComponent<GlitchEffect>().enabled = false;

        yield return new WaitForSeconds(2.5f);
        //enables logo.
        logo.SetActive(true);
    }
}
