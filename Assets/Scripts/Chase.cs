using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    //public exposed variable for player position. Drag fps player object in here.
    public Transform player;

    public float crawlingTheshold;
    public float attackingTheshold;
    public float movementSpeed = 0.1f;

    //animation variable.
    static Animator anim;

	// Use this for initialization
	void Start () {

        //populates the anim variable with the Animator on this object.
        anim = GetComponent<Animator>();

        player = GameObject.Find ("FeetPlacement").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        //Transform rotatedTransform = this.transform.position 
        //Measures the distance between the player object and this object. If less than 10 then---
        if(Vector3.Distance(player.position, this.transform.position) < 10)
        {
            //calculates a direct line between the player and this object.
            Vector3 direction = player.position - this.transform.position;

            //will stop the object from leaning backwards ie looking up or down.
            direction.y = 0;

            //rotates this object to look at the player.
            //uses a Lerp function so that it moves smoothly. At the speed on 0.1f
            Quaternion rotationAmount = Quaternion.Euler(0, 90, 0);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                       (Quaternion.LookRotation(direction) * rotationAmount), 0.1f);

            anim.SetBool("isIdle", true);
           // anim.SetBool("isAttacking", false);
            anim.SetBool("isCrawling", false);


            //movement. Magnitude is another word for length of vector.
            if(direction.magnitude > 2)
            {
                
                Debug.Log("greater than 1");
                if (direction.magnitude > crawlingTheshold)
                {
                    //Translate moves the transform.
                    this.transform.Translate(movementSpeed, 0, 0);
                    // this.transform.position = Vector3.Slerp(this.transform.position, 
                    //                                                        player.transform.position, movementSpeed);
                    anim.SetBool("isCrawling", true);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isIdle", false);
                }
            }
            if (direction.magnitude < attackingTheshold)
            {
                Debug.Log("less than 1");
                this.transform.position = this.transform.position;

                anim.SetBool("isCrawling", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isAttacking", true);
            }
        }
		
	}
}
