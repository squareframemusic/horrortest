using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyStuff : MonoBehaviour {

    private GlitchEffect glitchCameraEffect;

	// Use this for initialization
	void Start () {
        glitchCameraEffect = GetComponent<GlitchEffect>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown ("g"))
        {
            //the ! is a toggle. It means "make it whatever it isn't right now."
            glitchCameraEffect.enabled = !glitchCameraEffect.enabled;
        }
	}
}
