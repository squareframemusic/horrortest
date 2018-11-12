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

    //FMOD collision sounds for hosptital equipment.
    FMOD.Studio.EventInstance hospitalEquipmentAudio;
    FMOD.Studio.ParameterInstance hospitalEquipmentCollisionParameter;

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

    public void TrollyCollision(float vel, Vector3 position)
    {
        var trollySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalEquipment 01");
        FMOD.Studio.ParameterInstance collisionVel;

        trollySound.getParameter("collisionVelocity", out collisionVel);
        collisionVel.setValue(vel);
        trollySound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
        trollySound.start();
        trollySound.release(); //destroys the instance from memory once audio has played. Prevents memory leak.
    }

}

