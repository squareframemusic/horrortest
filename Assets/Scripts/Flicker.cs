using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

    public GameObject obj;
    public float timer;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlickeringDoll());
    }
	
	IEnumerator FlickeringDoll()
    {
        obj.SetActive(false);
        timer = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(timer);
        obj.SetActive(true);
        timer = Random.Range(0.1f,0.5f);
        yield return new WaitForSeconds(timer);
        obj.SetActive(false);
        timer = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlickeringDoll());
    }
}
