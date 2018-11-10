using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerDoll : MonoBehaviour {

    public GameObject doll;
    public float timer;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlickeringDoll());
    }
	
	IEnumerator FlickeringDoll()
    {
        doll.SetActive(false);
        timer = Random.Range(0.1f, 1);
        yield return new WaitForSeconds(timer);
        doll.SetActive(true);
        timer = Random.Range(0.1f, 1);
        yield return new WaitForSeconds(timer);
        doll.SetActive(false);
        timer = Random.Range(0.1f, 1);
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlickeringDoll());
    }
}
