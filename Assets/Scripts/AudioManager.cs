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


    //currently the methods TrollyCollision, CupCollision and HospitalBedCollision are using the same
    //fmod parameter. This may need to be changed after testing.
    public void TrollyCollision(float vel, Vector3 position)
    {
        var trollySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/TrolleyCollide");
        FMOD.Studio.ParameterInstance collisionVel;

        trollySound.getParameter("TrolleyCollisionVelocity", out collisionVel);
        collisionVel.setValue(vel);
        trollySound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
        trollySound.start();
        trollySound.release(); //destroys the instance from memory once audio has played. Prevents memory leak.
    }

    public void CupCollision(float vel, Vector3 position)
    {
        var trollySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/CupCollide");
        FMOD.Studio.ParameterInstance collisionVel;

        trollySound.getParameter("collisionVelocity", out collisionVel);
        collisionVel.setValue(vel);
        trollySound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
        trollySound.start();
        trollySound.release(); //destroys the instance from memory once audio has played. Prevents memory leak.
    }

    public void HospitalBedCollision(float vel, Vector3 position)
    {
        var trollySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalBedCollide");
        FMOD.Studio.ParameterInstance collisionVel;

        trollySound.getParameter("collisionVelocity", out collisionVel);
        collisionVel.setValue(vel);
        trollySound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
        trollySound.start();
        trollySound.release(); //destroys the instance from memory once audio has played. Prevents memory leak.
    }

}

