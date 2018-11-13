using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoll : MonoBehaviour {

    //game objects placed in 3D space where the wheels are.
    public GameObject wheelOneLocation;
    public GameObject wheelTwoLocation;
    public GameObject wheelThreeLocation;
    public GameObject wheelFourLocation;

    //Rigidbody for the bed. Used to calculate velocity magnitude.
    public Rigidbody bedRigidBody;

    //one single float used for velocity to limit the number of calculations in the update function.
    public float bedVelocity;

    //fmod event instance for each wheel.
    //Wheel 1.
    FMOD.Studio.EventInstance wheelOneEvent;
    FMOD.Studio.ParameterInstance wheelIndexOne;
    FMOD.Studio.ParameterInstance vel1;
    //Wheel 2.
    FMOD.Studio.EventInstance wheelTwoEvent;
    FMOD.Studio.ParameterInstance wheelIndexTwo;
    FMOD.Studio.ParameterInstance vel2;
    //Wheel 3.
    FMOD.Studio.EventInstance wheelThreeEvent;
    FMOD.Studio.ParameterInstance wheelIndexThree;
    FMOD.Studio.ParameterInstance vel3;
    //Wheel 4.
    FMOD.Studio.EventInstance wheelFourEvent;
    FMOD.Studio.ParameterInstance wheelIndexFour;
    FMOD.Studio.ParameterInstance vel4;

    public bool audioStartStop = false;

    // Use this for initialization
    void Start () {
        //Populates fmod event and parameter variables. Sets wheel index number.
        wheelOneEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalBedRoll");
        wheelOneEvent.getParameter("WheelNumber", out wheelIndexOne);
        wheelIndexOne.setValue(1f);
        wheelOneEvent.getParameter("RollSpeed", out vel1);

        wheelTwoEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalBedRoll");
        wheelTwoEvent.getParameter("WheelNumber", out wheelIndexTwo);
        wheelIndexTwo.setValue(2f);
        wheelTwoEvent.getParameter("RollSpeed", out vel2);

        wheelThreeEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalBedRoll");
        wheelThreeEvent.getParameter("WheelNumber", out wheelIndexThree);
        wheelIndexThree.setValue(3f);
        wheelThreeEvent.getParameter("RollSpeed", out vel3);

        wheelFourEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/HospitalBedRoll");
        wheelFourEvent.getParameter("WheelNumber", out wheelIndexFour);
        wheelIndexFour.setValue(4f);
        wheelFourEvent.getParameter("RollSpeed", out vel4);
    }
	
	// Update is called once per frame
	void Update () {

        //calculates and updates the velocity that the bed is travelling in any direction.
        bedVelocity = bedRigidBody.velocity.magnitude;
        UpdateVelocities(bedVelocity);

        if (bedVelocity > 0.005)
        {
            //start fmod wheel events.
            StartBedEvents();

            //update velocity fmod parameters.
            //UpdateVelocities(bedVelocity);

            //updates the 3D positioning of the wheels.
            UpdateWheelLocations();

        }
        else if (bedVelocity < 0.005)
        {
            //stops fmod wheel events.
            StopBedEvents();
            //UpdateVelocities(bedVelocity);
        }
	}

    //starts all bed rolling fmod event instances.
    void StartBedEvents ()
    {
        if (audioStartStop == false)
        {
            audioStartStop = true;
            wheelOneEvent.start();
            wheelTwoEvent.start();
            wheelThreeEvent.start();
            wheelFourEvent.start();
        }
    }

    //stops all bed rolling fmod event instances.
    void StopBedEvents()
    {
        if (audioStartStop == true)
        {
            audioStartStop = false;
            wheelOneEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            wheelTwoEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            wheelThreeEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            wheelFourEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    
    //sets all RollSpeed parameters in the fmod events to the rigidbody velocity.magnitude.
    void UpdateVelocities(float vel)
    {
        vel1.setValue(vel);
        vel2.setValue(vel);
        vel3.setValue(vel);
        vel4.setValue(vel);
    }

    void UpdateWheelLocations ()
    {
        wheelOneEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(wheelOneLocation.transform.position));
        wheelTwoEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(wheelTwoLocation.transform.position));
        wheelThreeEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(wheelThreeLocation.transform.position));
        wheelFourEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(wheelFourLocation.transform.position));
    }
}
