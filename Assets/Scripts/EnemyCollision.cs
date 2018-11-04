using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public GameObject playerObject;
    public GameObject partTwoStartPoint;
    public GameObject door;

    private void Start()
    {
        //populates the playerObject variable.
        playerObject = GameObject.Find("FPSController");

        //populates the partTwoStartPoint variable.
        partTwoStartPoint = GameObject.Find("playerPart2Start");

        //populates the door variable.
        door = GameObject.Find("TimsAssets_Door");
    }

    //detects collision between the player and the enemy.
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartPartTwo();
            Debug.Log("Enemy Hit Player");
        }
    }

    //moves the player to the starting point for part two of the horror game.
    void StartPartTwo()
    {
        //Teleports player.
           playerObject.transform.position = partTwoStartPoint.transform.position;
           
        
    }
}
