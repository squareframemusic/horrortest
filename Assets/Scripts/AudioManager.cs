using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class AudioManager : MonoBehaviour
{
    //FMOD
    //Footsteps.
    FMOD.Studio.EventInstance footStep;
    public GameObject firstPersonFoot;

    //singleton.
    public static AudioManager instance;

    private void Awake()
    {
            //singleton.
        instance = this;

//        footStep = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Footsteps");
    }

    public void PlayFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Footsteps", firstPersonFoot.transform.position);
    }

}

